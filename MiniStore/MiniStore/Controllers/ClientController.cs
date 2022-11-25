﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using MiniStore.ViewModels.Cart;
using MiniStore.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ClientController(
            MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Client
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["name"] = user.FirstName + " " + user.LastName;

            return View();
        }

        // GET: /Client/Details
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                var commandes = _context.Commands.Where(c => c.UserId == user.Id).ToList();

                var model = commandes.Select(c => new CommandViewModel
                {
                    Id = c.Id,
                    Items = CommandMapping(c),
                    Status = GestionStatusCommand(c)
                }).OrderBy(co => co.Status).ToList();

                return View(model);
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListAdmin()
        {
            // ToDo: Prendre toutes les commandes (clients, status, ItemInCart,  ...)
            return View();
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

        private string GestionStatusCommand(Commande command)
        {
            if (command.IsSent) return "En Livraison";
            else if (command.IsPaid) return "En Préparation";

            // Si la commande n'a aucun article elle est annulée
            if (_context.ItemInCarts.Where(i => i.CommandeId == command.Id).Count() == 0)
                return "Annulée";

            // Si la commande a une addresse
            if (command.AddressId is not null) return "Confirmée";

            return "En Attente";
        }
    }
}
