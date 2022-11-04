using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.ViewModels.Cart;

namespace MiniStore.Controllers
{
    public class CartController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CartController(MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        // ToDo: GET ListCart / Index
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // List par rôle
            if (User.IsInRole("Admin"))
            {
                var carts = await _context.Carts.ToListAsync();

                var liste = _context.Carts.ToList().Select(x =>
                new CartViewModels.CartViewModel(
                    x.UserId,
                    _context.ItemInCarts.ToList().Select(i =>
                        new CartViewModels.ItemInCartModel(i.Id, i.Mini.Name, i.Mini.ImagePath, i.Quantity, i.Mini.ReducedPrice))
                        .ToList(),
                    x.items.Sum(x => x.Mini.ReducedPrice)));
                
                return View("AdminIndex", liste);
            }

            if (User.IsInRole("Client"))
            {
                var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).ToListAsync();
                
                var list = cart.Select(x => new CartViewModels.CartViewModel(
                    x.UserId, 
                    _context.ItemInCarts.ToList().Select(i => 
                        new CartViewModels.ItemInCartModel(i.Id, i.Mini.Name, i.Mini.ImagePath, i.Quantity, i.Mini.ReducedPrice))
                        .ToList(), 
                    x.items.Sum(x => x.Mini.ReducedPrice)));
                
                return View("Index", cart);
            }

            return NotFound();
        }

        // ToDo: Regarder comment fonctionne le post du formulaire du component InfoItemMini
        // ToDo: Regarder où passe les infos du post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AjouterItemPanier(MinisDetails mini)
        {
            // User
            if (_userManager.GetUserId(User) == null)
                RedirectToAction("LogIn", "Account");

            // Quantity
            if (mini.Quantity < 0)
                RedirectToAction("Item", "Shop", new { id = mini.Id });

            // Mini
            var entity = await _context.Minis.FindAsync(mini.Id);
            if (entity == null)
                RedirectToAction("Item", "Shop", new { id = mini.Id });

            // Cart
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            if (cart == null)
            {
                cart = new Cart { UserId = _userManager.GetUserId(User) };
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }

            var item = new ItemInCart
            {
                MiniId = mini.Id,
                Mini = entity,
                Quantity = mini.Quantity,
                CartId = cart.Id,
                Cart = cart
            };

            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ToDo: GET IncItem
        [Authorize]
        public async Task<IActionResult> IncItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            item.Quantity++;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ToDo: GET DecItem
        [Authorize]
        public async Task<IActionResult> DecItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            item.Quantity--;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // ToDo: GET DeleteItem
        [Authorize]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            
            _context.ItemInCarts.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
