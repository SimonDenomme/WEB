using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.ViewModels.Cart;
using System.Collections.Generic;
using System;

namespace MiniStore.Controllers
{
    public class CartController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(MiniStoreContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private CartViewModels.CartViewModel CartMapping(Cart cart)
        {
            if (cart == null)
                return null;
            var items = _context.ItemInCarts.Where(i => i.CartId == cart.Id && i.CommandeId == null).ToList();
            if (items.Count == 0)
                return null;

            var sousTotal = _context.ItemInCarts.Where(x => x.CartId == cart.Id).Select(y => y.Mini.ReducedPrice * y.Quantity).Sum();

            var list = new CartViewModels.CartViewModel(
                cart.Id,
                _context.Users.Find(cart.UserId).UserName,
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

        // GET ListCart / Index
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var carts = await _context.Carts.ToListAsync();
                var model = new List<CartViewModels.CartViewModel>();

                if (carts.Count == 0) return View("EmptyCart");

                foreach (var cart in carts)
                {
                    var mapping = CartMapping(cart);
                    if (mapping == null) return View("EmptyCart");

                    model.Add(mapping);
                }

                return View("AdminIndex", model);
            }

            if (User.IsInRole("Client"))
            {
                var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();

                var model = CartMapping(cart);
                if (model == null) return View("EmptyCart");

                return View(model);
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
        public async Task<IActionResult> AjouterItemPanier(int MiniId, int Quantity)
        {
            // User
            if (User?.Identity?.IsAuthenticated == false || _userManager.GetUserId(User) == null)
                return RedirectToAction("ConfirmBuying", new { MiniId = MiniId, Quantity = Quantity });

            // Quantity
            if (Quantity < 1)
                return RedirectToAction("Item", "Shop", new { id = MiniId });

            // Mini
            var entity = await _context.Minis.FindAsync(MiniId);
            if (entity == null)
                return RedirectToAction("Index", "Shop");

            // Cart
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            if (cart == null)
            {
                cart = new Cart { UserId = _userManager.GetUserId(User) };
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }

            // Valider si déjà dans le panier
            var item1 = await _context.ItemInCarts.Where(i => i.MiniId == MiniId && i.CartId == cart.Id).FirstOrDefaultAsync();
            if (item1 != null)
                item1.Quantity++;
            else
            {
                var item = new ItemInCart
                {
                    MiniId = MiniId,
                    Mini = entity,
                    Quantity = Quantity,
                    CartId = cart.Id,
                };

                _context.Add(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmBuying(int MiniId, int Quantity)
        {
            var model = new ConfirmBuying
            {
                MiniId = MiniId,
                Quantity = Quantity,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmBuying(ConfirmBuying model)
        {
            // ToDo: Création d'un nouveau user pour l'invité
            // Ou alors on doit mettre son Guid de ID dans les claims
            
            return RedirectToAction("");
        }

        // GET IncItem
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
        public async Task<IActionResult> DecItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            item.Quantity--;

            if (item.Quantity < 1)
                item.Quantity = 1;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET DeleteItem
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.ItemInCarts.FindAsync(id);
            int? cartId = item.CartId;

            _context.ItemInCarts.Remove(item);
            await _context.SaveChangesAsync();

            if (_context.ItemInCarts.Where(i => i.CartId == cartId).Count() == 0)
            {
                var cart = await _context.Carts.FindAsync(cartId);
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
