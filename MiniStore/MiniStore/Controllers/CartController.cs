using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Entity;
using MiniStore.Models;
using System.Linq;
using System.Threading.Tasks;

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

        // ToDo: Ramasser les informations de la quantité, l'id de litem
        // ToDo: Regarder comment fonctionne le post du formulaire du component InfoItemMini
        // ToDo: Regarder où passe les infos du post
        [HttpPost]
        public async Task<IActionResult> AjouterItemPanier(MinisDetails mini)
        {
            // Quantity
            if (mini.Quantity < 0)
                RedirectToAction("Item", "Shop", new { id = mini.Id });

            // Mini
            var entity = await _context.Minis.FindAsync(mini.Id);
            if (entity == null)
                RedirectToAction("Item", "Shop", new { id = mini.Id });

            // User
            if (_userManager.GetUserId(User) == null)
                RedirectToAction("LogIn", "Account");
            
            // Cart
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            if (cart == null){
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
        public async Task<IActionResult> IncItem()
        {
            return View();
        }
        
        // ToDo: GET DecItem
        public async Task<IActionResult> DecItem()
        {
            return View();
        }
        
        // ToDo: GET ListCart / Index
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // ToDo: GET DeleteItem
        public async Task<IActionResult> DeleteItem()
        {
            return View();
        }
    }
}
