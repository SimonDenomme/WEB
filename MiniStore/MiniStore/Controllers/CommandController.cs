﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
//using MiniStore.Entity;
using MiniStore.Models;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Controllers
{
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



        //public IActionResult Index()
        //{
        //    return View("CommandInfos");
        //}

        public async Task<IActionResult> CommandForm(int Id)
        {
            return View();
        }



        public async Task<IActionResult> CancelCommand(int Id)
        {
            var command = await _context.Carts.FindAsync(Id);
            command.IsCommand = false;
            return View();
        }
        
        public async Task<IActionResult> CreateCommand(int cartId)
        {
            var Command = await _context.Carts.FindAsync(cartId);
            Command.IsCommand = true;
            var commandModel = new Commande
            {
                Items = Command,
                UserId = _userManager.GetUserId(User)
            };
            _context.Add(commandModel);
            await _context.SaveChangesAsync();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("CommandForm", cartId);
            }
            return RedirectToAction("LogIn", "Account");


            //return View();
        }

        public async Task<IActionResult> CommandInfos()
        {
            var Command = _context.Commands.Where(c => c.IsSent == false).FirstOrDefault();
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();

            var commandModel = new CommandModel
            {
                Cart = cart
            };

            return View(commandModel);
        }
        

    }
}
