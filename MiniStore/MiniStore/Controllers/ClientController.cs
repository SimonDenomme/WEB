using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Domain;

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
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClientController/Details
        [Authorize(Roles = "Client")]
        public ActionResult Details()
        {
            return View();
        }

        
    }
}
