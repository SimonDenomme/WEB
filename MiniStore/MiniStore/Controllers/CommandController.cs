using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using MiniStore.ViewModels.Cart;
using System.Linq;
using System.Threading.Tasks;
using static MiniStore.ViewModels.Cart.CartViewModels;

namespace MiniStore.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> CommandForm(int cartId)
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
            var commandModel = new Commande
            {
                IsSent = true,
                Items = Command,
                UserId = _userManager.GetUserId(User),
            };
            _context.Add(commandModel);
            await _context.SaveChangesAsync();

            var items = await _context.ItemInCarts.Where(i => i.CartId == cartId).ToListAsync();
            foreach (var i in items)
            {
                i.CommandeId = commandModel.Id;
                _context.Update(i);
            }
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
            //var Command = _context.Commands.Where(c => c.IsSent == false).FirstOrDefault();
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            var items =  await _context.ItemInCarts.Where(i => i.CartId == cart.Id).ToListAsync();

            //CartMapping()


            //var cart1 = new CartViewModel(cart.Id,
            //     "",
            //    items,
            //     0.0d,
            //     0.0d,
            //     0.0d);
            var commandModel = new CommandModel()
            {
                items = items
            };

            return View(commandModel);
        }

        private CartViewModels.CartViewModel CartMapping(Cart cart)
        {
            var items = _context.ItemInCarts.Where(i => i.CartId == cart.Id).ToList();
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
    }

}
