﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using MiniStore.ViewModels.Cart;
using MiniStore.ViewModels.Command;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniStore.Controllers
{
	[Authorize]
	public class CommandController : Controller
	{
		private readonly MiniStoreContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IOptions<StripeOptions> _stripeOptions;

		public CommandController(MiniStoreContext context,
			UserManager<ApplicationUser> userManager,
			IOptions<StripeOptions> stripeOptions)
		{
			_context = context;
			_userManager = userManager;
			_stripeOptions = stripeOptions;
		}

		// Confirmer le panier -> Rentrer les infos de la command (livraison/address)           => CreateCommand -> CommandForm
		// Confirmer la commande -> Créer la facture et ferme la modification de la command     => CommandInfos
		// Payer la facture -> Créer le reçu et ferme la modification de la facture             => PayBill

		public async Task<IActionResult> CreateCommand(Guid cartId)
		{
			var cart = await _context.Carts.FindAsync(cartId);

			var items = await _context.ItemInCarts.Where(i => i.CartId == cartId && i.CommandeId == null).ToListAsync();
			var adresse = await _context.Addresses.Where(a => a.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();

			var command = new Commande
			{
				IsSent = false,
				IsPaid = false,
				UserId = _userManager.GetUserId(User),
				CommandStatusId = 1, // À Valider
				AddressId = adresse != null ? adresse.Id : null
			};

			_context.Add(command);
			await _context.SaveChangesAsync();

			foreach (var i in items)
			{
				i.CommandeId = command.Id;
				i.CartId = null;
				_context.Update(i);
			}
			await _context.SaveChangesAsync();

			_context.Remove(cart);
			await _context.SaveChangesAsync();

			return RedirectToAction("CommandForm", new { id = command.Id });
		}

		public async Task<IActionResult> CommandForm(Guid id)
		{
			var command = await _context.Commands.FindAsync(id);
			if (command == null)
				return NotFound();

			var model = new CommandForm();
			var user = await _userManager.GetUserAsync(HttpContext.User);
			if (command.UserId == user.Id)
			{
				var address = _context.Addresses.Where(a => a.UserId == user.Id).FirstOrDefault();
				if (address is not null)
				{
					model.Number = address.Number;
					model.Street = address.Street;
					model.City = address.City;
					model.PostalCode = address.PostalCode;
				}

				model.Id = command.Id;
				model.FirstName = user.FirstName;
				model.LastName = user.LastName;
				model.Email = user.Email;
				model.CellPhone = user.PhoneNumber;
				model.Addresses = FillDropDownAddress();
				model.Cart = CommandMapping(command);
			}

			else
			{
				model.Id = command.Id;
				model.AdresseId = command.AddressId;
				model.Cart = CommandMapping(command);
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CommandForm(CommandForm model)
		{
			if (!ModelState.IsValid) return RedirectToAction("CommandForm", new { id = model.Id });

			var command = await _context.Commands.FindAsync(model.Id);

			int add;
			bool success = int.TryParse(model.SelectedAddress, out add);

			//ToDo: checker adresse

			// recup les adreses en memoire et comparer
			var req = _context.Addresses.Where(
					a => a.UserId.Equals(_userManager.GetUserId(User)) &&
					a.Number == model.Number &&
					a.Street == model.Street &&
					a.City == model.City &&
					a.PostalCode == model.PostalCode
				).FirstOrDefault();
			if (req is not null)
			{
				command.Address = req;
				command.AddressId = req.Id;
			}
			else
			{
				var address = new Domain.Address
				{
					Number = model.Number,
					Street = model.Street,
					City = model.City,
					PostalCode = model.PostalCode,
					UserId = command.UserId
				};
				command.Address = address;
				_context.Addresses.Add(address);
			}

			_context.Update(command);
			await _context.SaveChangesAsync();

			return RedirectToAction("CommandInfos", new { id = command.Id });
		}

		public async Task<IActionResult> CancelCommand(Guid? id)
		{
			// Ne doit pas détruire le lien ItemInCart & Command
			var command = await _context.Commands.FindAsync(id);
			if (command is null) return NotFound();

			var items = await _context.ItemInCarts.Where(i => i.CommandeId == command.Id).ToListAsync();
			if (items is null) return NotFound();

			var cart = await _context.Carts.Where(c => c.UserId == command.UserId).FirstOrDefaultAsync();
			if (cart is null)
				cart = new Cart { items = items, UserId = command.UserId, IsCommand = false };

			command.CommandStatusId = 3; // Annulée
										 //foreach (var i in items) {
										 //    i.CommandeId = null;
										 //    i.CartId = cart.Id;
										 //    _context.ItemInCarts.Update(i);
										 //}
			_context.Carts.Add(cart);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Cart");
		}

		// https://stripe.com/docs/testing?testing-method=card-numbers
		public async Task<IActionResult> PayBill(Guid? id)
		{
			var command = await _context.Commands.FindAsync(id);
			if (command is null) return NotFound();
			command.CommandStatusId = 2; // Confirmée
			await _context.SaveChangesAsync();

			var cart = CommandMapping(command);

			//description
			String name = "";
			int tempSize = cart.ItemsInCart.Count();

            for (int i = 0; i < tempSize; i++)
			{
				name += i == tempSize? cart.ItemsInCart[i].Name + " ," : cart.ItemsInCart[i].Name + ".";
            }
			var model = new ProductModel
			{
				Name = cart.Id.ToString(),
				Price = Math.Round(cart.Total * 100, 2, MidpointRounding.ToEven),
			};
			return View(model);
		}

		public async Task<IActionResult> CommandInfos(Guid? id)
		{
			var command = await _context.Commands.FindAsync(id);
			if (command is null) return NotFound();

			var user = await _userManager.FindByIdAsync(command.UserId);
			if (user is null) return Forbid();

			var address = await _context.Addresses.FindAsync(command.AddressId);
			if (address is null) return NotFound();

			var items = CommandMapping(command);

			var model = new CommandInfos
			{
				Id = command.Id,

				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				CellPhone = user.PhoneNumber,

				Number = address.Number,
				Street = address.Street,
				City = address.City,
				PostalCode = address.PostalCode,

				Items = items,

				FraisLivraison = items.Total * 0.05,
				IsConfirmable = command.CommandStatusId == 1
			};

			return View(model);
		}

		[HttpPost]
		public async Task<JsonResult> Charges([FromBody] ChargesModel model)
		{
			StripeConfiguration.ApiKey = _stripeOptions.Value.SecretKey;

			var options = new ChargeCreateOptions
			{
				Amount = model.AmountInCents,
				Description = model.Description,
				Source = model.Token,
				Currency = model.CurrencyCode,
			};
			var service = new ChargeService();
			var charge = service.Create(options);

			var command = await _context.Commands.FindAsync(new Guid(model.Description));
			if (command is null) return Json(new { success = false, message = "Commande introuvable" });
			command.CommandStatusId = 4; // En Préparation

			// ToDo: Trouver une meilleure façon de gérer l'addresse
			var add = await _context.Addresses.FindAsync(command.AddressId);
			if (add is null) return Json(new { success = false, message = "Adresse introuvable" });

			var bill = new Bill
			{
				CommandId = command.Id,
				Date = charge.Created,
				Name = model.Name,
				Address = add.Number.ToString() + " " + add.Street + " " + add.City + ", " + add.PostalCode,
				Phone = model.Phone,
				CreditCard = charge.PaymentMethodDetails.Card.Last4,
			};
			await _context.Bills.AddAsync(bill);
			await _context.SaveChangesAsync();

			return Json(charge.ToJson());
		}
		public IActionResult Confirmation() { return View(); }

		public async Task<IActionResult> BillHistoric(Guid? id)
		{
			var command = await _context.Commands.FindAsync(id);
			if (command is null) return NotFound();

			var bill = await _context.Bills.Where(b => b.CommandId.Equals(id)).FirstOrDefaultAsync();
			if (bill is null) return NotFound();

			var model = new BillViewModel
			{
				Date = bill.Date.ToString(),
				Name = bill.Name,
				Address = bill.Address,
				Phone = bill.Phone,
				CreditCard = "**** **** **** " + bill.CreditCard,
				CommandId = bill.CommandId.ToString(),
				CommandStatus = _context.CommandStatus.Find(command.CommandStatusId).Status,
				Items = CommandMapping(command)
			};

			return View(model);
		}
		private CartViewModels.CartViewModel CommandMapping(Commande command)
		{
			if (command == null)
				return null;
			var items = _context.ItemInCarts.Where(i => i.CommandeId == command.Id).ToList();
			if (items.Count == 0)
				return null;

			var sousTotal = _context.ItemInCarts.Where(x => x.CommandeId == command.Id).Select(y => y.Mini.ReducedPrice * y.Quantity).Sum();

			var list = new CartViewModels.CartViewModel(
				command.Id,
				_context.Users.Find(command.UserId).UserName,
				items.Select(i =>
					new CartViewModels.ItemInCartModel(
						i.Id,
						_context.Minis.Find(i.MiniId).Name,
						_context.Minis.Find(i.MiniId).ImagePath,
						i.Quantity,
						_context.Minis.Find(i.MiniId).ReducedPrice)).ToList(),
				sousTotal,
				sousTotal * 0.15,
				sousTotal * 1.15);

			return list;
		}

		private IEnumerable<SelectListItem> FillDropDownAddress()
		{
			var addresses = _context.Addresses.Where(a => a.UserId.Equals(_userManager.GetUserId(User))).ToList();
			var list = addresses.Select(a => new SelectListItem
			{
				Value = a.Id.ToString(),
				Text = a.Number + " " + a.Street + ", " + a.City + ", " + a.PostalCode
			});
			return list;
		}
	}
}
