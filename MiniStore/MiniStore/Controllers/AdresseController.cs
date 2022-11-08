using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.ViewModels.Adresse;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniStore.Controllers
{
    public class AdresseController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdresseController(
            MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdresseViewModel model, string name, string returnurl)
        {
            var address = new Address
            {
                Number = model.AddressNumber,
                Street = model.AddressStreet,
                City = model.AddressCity,
                PostalCode = model.AddressPostalCode,
            };
            var user = await _userManager.FindByNameAsync(name);
            try
            {
                if (user.Address == null)
                {
                    user.Address = new List<Address>();
                }
                user.Address.Add(address);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unable to add address to user!");
            }
            //_context.SaveChanges();
            try
            {
                //_context.Attach(user);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to add address!");
                return View(model);
            }
            //return View(returnurl);
            return RedirectToAction("Index", "Home");
        }
    }
}
