using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Domain;
using MiniStore.Models;
using System.Linq;
using System.Threading.Tasks;

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

        // ToDo: GET CommandForm
        public async Task<IActionResult> CommandForm(int cartId)
        {
            return View();
        }

        // ToDo: GET CancelCommand
        public async Task<IActionResult> CancelCommand(int Id)
        {
            var command = await _context.Carts.FindAsync(Id);
            command.IsCommand = false;
            return View();
        }

        // ToDo: GET CreateCommand
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
        }

        // ToDo: GET CommandInfos
        public async Task<IActionResult> CommandInfos()
        {
            var cart = await _context.Carts.Where(c => c.UserId.Equals(_userManager.GetUserId(User))).FirstOrDefaultAsync();
            var items =  await _context.ItemInCarts.Where(i => i.CartId == cart.Id).ToListAsync();

            var commandModel = new CommandModel()
            {
                items = items
            };

            return View(commandModel);
        }
    }

}
