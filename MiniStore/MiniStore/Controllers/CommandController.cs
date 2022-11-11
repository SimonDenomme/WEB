﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using MiniStore.ViewModels.Cart;
using MiniStore.ViewModels.Command;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Controllers
{
    [Authorize]
    public class CommandController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CommandController(MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Confirmer le panier -> Rentrer les infos de la command (livraison/address)           => CreateCommand
        // Confirmer la commande -> Créer la facture et ferme la modification de la command     => CommandForm
        // Payer la facture -> Créer le reçu et ferme la modification de la facture             => PayBill

        // GET CreateCommand
        public async Task<IActionResult> CreateCommand(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            var items = await _context.ItemInCarts.Where(i => i.CartId == cartId && i.CommandeId == null).ToListAsync();
            var adresse = await _context.Addresses.Where(a => a.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();

            var command = new Commande
            {
                IsSent = false,
                Items = cart,
                UserId = _userManager.GetUserId(User),
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

            return RedirectToAction("CommandForm", new { id = command.Id });
        }


        // ToDo: GET CommandForm
        public async Task<IActionResult> CommandForm(int id)
        {
            var command = await _context.Commands.FindAsync(id);
            if (command == null)
                return NotFound();

            var model = new CommandForm
            {
                Id = command.Id,
                Addresses = FillDropDownAddress(),
                Number = 0,
                Street = "",
                City = "",
                PostalCode = "",
                Cart = CommandMapping(command)
            };

            return View(model);
        }

        // ToDo: POST CommandForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommandForm(CommandModel model)
        {
            if (ModelState.IsValid)
            {
                var command = await _context.Commands.FindAsync(model.Id);
                command.IsSent = true;
                _context.Update(command);
                await _context.SaveChangesAsync();

                // Co-Pilot m'a sortie ça je sais pas si c'est bon, mais ça semble efficace
                //var bill = new Bill
                //{
                //    CommandeId = command.Id,
                //    IsPaid = false,
                //    UserId = command.UserId,
                //    AddressId = model.AddressId,
                //    Number = model.Number,
                //    Street = model.Street,
                //    City = model.City,
                //    PostalCode = model.PostalCode
                //};

                //_context.Add(bill);
                //await _context.SaveChangesAsync();

                //return RedirectToAction("PayBill", new { id = bill.Id });
            }
            return View(model);
        }

        // ToDo: GET CancelCommand
        public async Task<IActionResult> CancelCommand(int id)
        {
            var command = await _context.Carts.FindAsync(id);
            command.IsCommand = false;
            return View();
        }

        // ToDo: GET PayBill
        public async Task<IActionResult> PayBill(int? id)
        {
            // ToDo: Fermer la modification sur la facture (option de paiement)
            // ToDo: Faire le paiement
            // ToDO: Envoyer le colis
            return View();
        }

        // ToDo: GET CommandInfos
        public async Task<IActionResult> CommandInfos()
        {
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            var items = await _context.ItemInCarts.Where(i => i.CartId == cart.Id).ToListAsync();

            var command = await _context.Commands.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            var address = await _context.Addresses.Where(a => a.Id == command.AddressId).FirstOrDefaultAsync();

            foreach (var item in command.Items.items)
            {
                item.Mini = await _context.Minis.Where(m => m.Id == item.MiniId).FirstOrDefaultAsync();
            }
            var commandModel = new CommandModel()
            {
                Id = command.Id,
                UserId = command.UserId,
                IsSent = command.IsSent,
                //AddressId = address != null ? address.Id : 0,
                Number = address != null ? address.Number : 0,
                Street = address != null ? address.Street : "",
                City = address != null ? address.City : "",
                PostalCode = address != null ? address.PostalCode : "",
                Items = command.Items.items,
                CommandUser = await _userManager.GetUserAsync(User)
            };

            return View(commandModel);
        }

        private CartViewModels.CartViewModel CommandMapping(Commande command)
        {
            if (command == null)
                return null;
            var items = _context.ItemInCarts.Where(i => i.CommandeId == command.Id).ToList();
            if (items.Count == 0)
                return null;

            var sousTotal = _context.ItemInCarts.Where(x => x.CartId == command.Id).Select(y => y.Mini.ReducedPrice * y.Quantity).Sum();

            var list = new CartViewModels.CartViewModel(
                0,
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
