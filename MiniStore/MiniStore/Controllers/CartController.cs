using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
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

        // GET ListCart / Index
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // List par rôle
            if (User.IsInRole("Admin"))
            {
                var liste = _context.Carts.ToList().Select(c =>
                    new CartViewModels.CartViewModel(
                        _context.Users.Find(c.UserId).UserName,
                        _context.ItemInCarts.Where(i => i.CartId == c.Id).ToList().Select(i =>
                        new CartViewModels.ItemInCartModel(
                            i.Id,
                            _context.Minis.Find(i.MiniId).Name,
                            _context.Minis.Find(i.MiniId).ImagePath,
                            i.Quantity,
                            _context.Minis.Find(i.MiniId).ReducedPrice)),
                    _context.ItemInCarts.Where(i2 => i2.CartId == c.Id).Select(x => x.Mini.ReducedPrice).Sum()));

                return View("AdminIndex", liste);
            }

            if (User.IsInRole("Client"))
            {
                var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
                var items = await _context.ItemInCarts.Where(x => x.CartId == cart.Id).ToListAsync();

                var list = new CartViewModels.CartViewModel(
                    _context.Users.Find(cart.UserId).UserName,
                    items.Select(i =>
                        new CartViewModels.ItemInCartModel(
                            i.Id,
                            _context.Minis.Find(i.MiniId).Name,
                            _context.Minis.Find(i.MiniId).ImagePath,
                            i.Quantity,
                            _context.Minis.Find(i.MiniId).ReducedPrice)),
                    _context.ItemInCarts.Where(x => x.CartId == cart.Id).Select(x => x.Mini.ReducedPrice).Sum());

                return View("Index", list);
            }
            else
            {
                var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).ToListAsync();
                return RedirectToAction("CommandForm", "Command", cart);
            }
        }

        // POST AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AjouterItemPanier(int MiniId, int Quantity)
        {
            // User
            if (_userManager.GetUserId(User) == null)
                return RedirectToAction("LogIn", "Account");

            // Quantity
            if (Quantity < 1)
                return RedirectToAction("Item", "Shop", new { id = MiniId });

            // Mini
            var entity = await _context.Minis.FindAsync(MiniId);
            if (entity == null)
                return RedirectToAction("Item", "Shop", new { id = MiniId });

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
                MiniId = MiniId,
                Mini = entity,
                Quantity = Quantity,
                CartId = cart.Id,
                Cart = cart
            };

            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET IncItem
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

        // GET DecItem
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

        // GET DeleteItem
        [Authorize]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            int cartId = item.CartId;

            _context.ItemInCarts.Remove(item);

            if (_context.ItemInCarts.Where(i => i.CartId == cartId).Count() == 0)
            {
                var cart = await _context.Carts.FindAsync(cartId);
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
