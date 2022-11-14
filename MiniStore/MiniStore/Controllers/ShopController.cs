using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MiniStore.Domain;
using MiniStore.ViewModels.Shop;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MiniStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShopController(MiniStoreContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int iCount = _context.Minis.Count();

            ShopViewModel i = new ShopViewModel { TotalCount = iCount, TotalPage = NombrePage(iCount) };

            return View(i);
        }

        [HttpPost]
        public IActionResult Index(ShopViewModel i)
        {
            if (i.FiltreA || i.FiltreB || i.FiltreC)
                i.IsFiltered = true;
            if (!i.FiltreA)
            {
                i.IsLuminous = false;
                i.IsPainted = false;
            }
            if (!i.FiltreB)
            {
                i.MinPrice = 0;
                i.MaxPrice = 1000;
            }
            if (!i.FiltreC)
            {
                i.StatusId = 1;
            }
            return View(i);
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            var minis = _context.Minis.Where(m => m.Name.ToLower().Contains(search)).ToList();
            var miniSize = _context.Sizes.ToList();

            ShopViewModel i = new ShopViewModel { IsFiltered = true, IsPainted = search.Contains("#painted"), IsLuminous = search.Contains("#luminous"), Search = search, TotalCount = minis.Count, TotalPage = NombrePage(minis.Count) };

            return View("Index", i);
        }

        [Authorize]
        public IActionResult AdminProduit()
        {
            var minis = _context.Minis.ToList();
            var list = minis.Select(m =>
                new MiniViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    ImagePath = m.ImagePath,
                    NormalPrice = m.NormalPrice,
                    ReducedPrice = m.ReducedPrice,
                });

            return View(list);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SupprimerProduit(Guid? id)
        {
            try
            {
                var mini = await _context.Minis.FindAsync(id);
                _context.Minis.Remove(mini);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminProduit");
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }

        [Authorize]
        public async Task<IActionResult> ModifierProduit(Guid? id)
        {
            if (id == null)
                return NotFound();
            try
            {
                var mini = await _context.Minis.FindAsync(id);
                if (mini == null)
                    return NotFound();

                var edit = new EditMiniViewModel
                {
                    Id = mini.Id,
                    Name = mini.Name,
                    Description = mini.Description,
                    ImagePath = mini.ImagePath,
                    IsPainted = mini.IsPainted,
                    IsLuminous = mini.IsLuminous,
                    QtyInventory = mini.QtyInventory,
                    NormalPrice = mini.NormalPrice,
                    ReducedPrice = mini.ReducedPrice,
                    Categories = FillDropDownCategory(),
                    SelectedCategory = mini.CategoryId.ToString(),
                    Sizes = FillDropDownSize(),
                    SelectedSize = mini.SizeId.ToString(),
                    StatusIndiponible = mini.StatusId == 3
                };

                return View(edit);
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ModifierProduit(EditMiniViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "The model is not valid");
                return View(model);
            }
            try
            {
                var mini = await _context.Minis.FindAsync(model.Id);

                mini.Name = model.Name;
                mini.Description = model.Description;
                mini.ImagePath = model.ImagePath;
                mini.IsPainted = model.IsPainted;
                mini.IsLuminous = model.IsLuminous;
                mini.QtyInventory = model.QtyInventory;
                mini.NormalPrice = model.NormalPrice;
                mini.ReducedPrice = model.ReducedPrice;
                mini.CategoryId = int.Parse(model.SelectedCategory);
                mini.SizeId = int.Parse(model.SelectedSize);

                // { "En inventaire", "Précommande", "Indisponible", "En rupture de stock" }
                mini.StatusId = mini.QtyInventory > 0 ? 1 : 4;
                if (model.StatusIndiponible)
                    mini.StatusId = 3;

                _context.Update(mini);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminProduit");
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }

        [Authorize]
        public IActionResult AjouterProduit()
        {
            return View(new AddMiniViewModel
            {
                Categories = FillDropDownCategory(),
                Sizes = FillDropDownSize()
            });
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterProduit(AddMiniViewModel model)
        {
            var mini = new Mini
            {
                Name = model.Name,
                Description = model.Description,
                ImagePath = model.ImagePath,
                IsPainted = model.IsPainted,
                IsLuminous = model.IsLuminous,
                QtyInventory = model.QtyInventory,
                NormalPrice = model.Normalprice,
                ReducedPrice = model.ReducedPrice,
                CategoryId = int.Parse(model.SelectedCategory),
                SizeId = int.Parse(model.SelectedSize),
            };

            // { "En inventaire", "Précommande", "Indisponible", "En rupture de stock" }
            mini.StatusId = mini.QtyInventory > 0 ? 1 : 2;

            _context.Add(mini);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminProduit");
        }

        private IEnumerable<SelectListItem> FillDropDownCategory()
        {
            var categories = _context.Categories.ToList();
            var list = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            return list;
        }
        private IEnumerable<SelectListItem> FillDropDownSize()
        {
            var categories = _context.Sizes.ToList();
            var list = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            });
            return list;
        }

        public IActionResult Item(Guid id)
        {
            ViewData["itemId"] = id;
            return View();
        }

        private int NombrePage(int iCount)
        {
            int iTotalPage = iCount / 30;
            if (iCount % 30 != 0) iTotalPage++;

            return iTotalPage;
        }
    }
}
