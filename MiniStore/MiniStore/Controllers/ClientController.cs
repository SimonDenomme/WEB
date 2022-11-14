using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ClientController : Controller
    {
        private readonly MiniStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ClientController(
            MiniStoreContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: ClientController
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
              ViewData["name"] = user.FirstName+ " " +user.LastName;
                          
            return View();
        }

        // GET: ClientController/Details
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                //List<CommandModel> commandes /*= new List<CommandModel>()*/;
                var cdes = await _context.Commands.Where(c => c.UserId == user.Id)
                                                   .Select(c =>
                                                   new CommandModel
                                                   {
                                                       Cart = c.Items,
                                                       Id = c.Id
                                                   }).ToListAsync();

                return View(cdes);
            }
            catch
            {
                return StatusCode(500, "Server error");
            }            
        }        
    }
}
