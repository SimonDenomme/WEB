using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.ViewModels.Account;
using System.Collections.Generic;
using System;

namespace MiniStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult GuestCreate()
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create Address
            List<Address> lstAddress = new List<Address>();
            var address = new Address
            {
                Number = model.AddressNumber,
                Street = model.AddressStreet,
                City = model.AddressCity,
                PostalCode = model.AddressPostalCode,
            };
            lstAddress.Add(address);
            await _context.SaveChangesAsync();

            // Create UserModel
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = lstAddress,
            };

            // Create Role if not exists
            bool clientRoleExists = await _roleManager.RoleExistsAsync("Client");
            if (!clientRoleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Client"));
            }
            bool adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // Create User
            var createPowerUser = await _userManager.CreateAsync(user, model.Password);
            if (createPowerUser.Succeeded)
            {
                if (model.RoleUser == RegisterViewModel.Role.Administrateur)
                {
                    var testing = await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    var testing = await _userManager.AddToRoleAsync(user, "Client");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error adding the user to the database");
                return View(model);
            }

            return RedirectToAction(nameof(LogIn));
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create Address
            List<Address> lstAddress = new List<Address>();
            var address = new Address
            {
                Number = model.AddressNumber,
                Street = model.AddressStreet,
                City = model.AddressCity,
                PostalCode = model.AddressPostalCode,
            };
            lstAddress.Add(address);
            await _context.SaveChangesAsync();

            // Create UserModel
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = lstAddress,
            };
            // Create Role if not exists
            bool clientRoleExists = await _roleManager.RoleExistsAsync("Client");
            if (!clientRoleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Client"));
            }
            bool adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // Create User
            var createPowerUser = await _userManager.CreateAsync(user, model.Password);
            if (createPowerUser.Succeeded)
            {
                if (model.RoleUser == RegisterViewModel.Role.Administrateur)
                {
                    var testing = await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    var testing = await _userManager.AddToRoleAsync(user, "Client");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error adding the user to the database");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View(_userManager.Users);
        }
    }
}
