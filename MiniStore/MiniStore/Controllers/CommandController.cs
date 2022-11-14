using Microsoft.AspNetCore.Authorization;
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

        public CommandController(MiniStoreContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                IsPaid = false,
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

        // GET CommandForm
        public async Task<IActionResult> CommandForm(int id)
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
                    model.Addresses = FillDropDownAddress();
                    model.SelectedAddress = address.Id.ToString();
                }
                //else
                //model.Number = 0;

                model.Id = command.Id;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.CellPhone = user.PhoneNumber;
                model.Cart = CommandMapping(command);
            }

            else
            {
                model.Id = command.Id;
                model.Addresses = FillDropDownAddress();
                //model.Number = 0;
                model.Cart = CommandMapping(command);
            }
            return View(model);
        }

        // POST CommandForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommandForm(CommandForm model)
        {
            if (!ModelState.IsValid) return View(model);

            var command = await _context.Commands.FindAsync(model.Id);

            int add;
            bool success = int.TryParse(model.SelectedAddress, out add);
            if (success)
            {
                var liste = FillDropDownAddress();
                var value = liste.Where(a => a.Value.Equals(model.SelectedAddress)).FirstOrDefault();
                var address = _context.Addresses.Find(int.Parse(value.Value));

                command.AddressId = address.Id;
                command.Address = address;
            }
            else
            {
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
                    var address = new Address
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
            }

            _context.Update(command);
            await _context.SaveChangesAsync();

            return RedirectToAction("PayBill", new { id = command.Id });
        }

        // GET CancelCommand
        public async Task<IActionResult> CancelCommand(int? id)
        {
            var command = await _context.Commands.FindAsync(id);
            if (command is null) return NotFound();

            var items = await _context.ItemInCarts.Where(i => i.CommandeId == command.Id).ToListAsync();
            if (items is null) return NotFound();

            var cart = await _context.Carts.Where(c => c.UserId == command.UserId).FirstOrDefaultAsync();
            if (cart is null)
                cart = new Cart { items = items, UserId = command.UserId, IsCommand = false };

            foreach (var i in items)
            {
                i.CommandeId = null;
                i.CartId = cart.Id;
                _context.ItemInCarts.Update(i);
            }
            _context.Commands.Remove(command);
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cart");
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
