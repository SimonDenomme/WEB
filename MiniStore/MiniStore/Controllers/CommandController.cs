using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.ViewModels.Cart;
using MiniStore.ViewModels.Command;
using System;
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

        // Confirmer le panier -> Rentrer les infos de la command (livraison/address)           => CreateCommand -> CommandForm
        // Confirmer la commande -> Créer la facture et ferme la modification de la command     => CommandInfos
        // Payer la facture -> Créer le reçu et ferme la modification de la facture             => PayBill

        // GET CreateCommand
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

        // GET CommandForm
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
                //model.Addresses = FillDropDownAddress();
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

        // POST CommandForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommandForm(CommandForm model)
        {
            //LA VALIDATION DU MODÈLE N'EMBARQUE PAS, ALORS POUR PAS LE FAIRE CRACHER JE REDIRIGE SUR LA MEME PAGE
            if (!ModelState.IsValid) return RedirectToAction("CommandForm", new { id = model.Id });

            var command = await _context.Commands.FindAsync(model.Id);

            int add;
            //bool success = int.TryParse(model.SelectedAddress, out add);
            
            // checker adresse

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
            

            _context.Update(command);
            await _context.SaveChangesAsync();

            return RedirectToAction("CommandInfos", new { id = command.Id });
        }

        // GET CancelCommand
        public async Task<IActionResult> CancelCommand(Guid? id)
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
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cart");
        }

        // ToDo: GET PayBill
        public async Task<IActionResult> PayBill(Guid? id)
        {
            // ToDo: Fermer la modification sur la facture (option de paiement)
            // ToDo: Faire le paiement
            // ToDO: Envoyer le colis
            return View();
        }

        // ToDo: GET CommandInfos
        public async Task<IActionResult> CommandInfos(Guid? id)
        {
            var command = await _context.Commands.FindAsync(id);
            if (command is null) return NotFound();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user is null) return Forbid();

            var address = await _context.Addresses.Where(a => a.Id == command.AddressId).FirstOrDefaultAsync();
            if (address is null) return NotFound();

            var items = CommandMapping(command);

            var model = new CommandInfos
            {
                Id = command.Id,
                IsPaid = command.IsPaid,

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CellPhone = user.PhoneNumber,

                Number = address.Number,
                Street = address.Street,
                City = address.City,
                PostalCode = address.PostalCode,

                Items = items,

                FraisLivraison = items.Total * 0.05
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
                Guid.NewGuid(),
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
