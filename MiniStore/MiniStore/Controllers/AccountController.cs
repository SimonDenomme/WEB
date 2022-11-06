using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.ViewModels.Account;
using System.Collections.Generic;

namespace MiniStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, false);

            if (result.IsLockedOut)
            {
                return View("Lockout");
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "LogIn Failed.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            List<Address> lstAddress = new List<Address>();
            var address = new Address
            {
                Number = model.AddressNumber,
                Street = model.AddressStreet,
                City = model.AddressCity,
                PostalCode = model.AddressPostalCode,
            };
            lstAddress.Add(address);
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = lstAddress,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Unable to register!");
                return View(model);
            }

            try
            {
                _context.Attach(user);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to register!");
                return View(model);
            }

            return RedirectToAction(nameof(LogIn));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_userManager.Users);
        }
    }
}
