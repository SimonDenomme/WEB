using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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



        public IActionResult Index()
        {
            return View("CommandInfos");
        }

        public async Task<IActionResult> CommandForm(int Id)
        {
            return View();
        }

        public async Task<IActionResult> ConfirmCommand(CommandModel model)
        {





            return View();
        }

        public async Task<IActionResult> CancelCommand(int Id)
        {
            var command = _context.Carts.Where(c => c.Id == Id).FirstOrDefault();
            command.IsCommand = false;
            return View();
        }
        public async Task<IActionResult> CreateCommand(int Id)
        {
            var Command = _context.Carts.Where(c => c.Id == Id).FirstOrDefault();
            Command.IsCommand = true;
            var commandModel = new CommandModel
            {
                Cart = Command
            };
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("CommandForm", Id);
            }
            return RedirectToAction("LogIn", "Account");


            //return View();
        }

        public async Task<IActionResult> CommandInfos(int Id)
        {
            var Command = _context.Carts.Where(c => c.Id == Id).FirstOrDefault();
            var commandModel = new CommandModel
            {
                Cart = Command
            };

            return View();
        }
        

    }
}
