using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Domain;
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

        public IActionResult Index()
        {
            return View();
        }

        // ToDo: Ramasser les informations de la quantité, l'id de litem
        // ToDo: Regarder comment fonctionne le post du formulaire du component InfoItemMini
        // ToDo: Regarder où passe les infos du post
        public async Task<IActionResult> PanierItem(MinisDetails mini)
        {
            if (mini.Quantity > 0) { }
            return View();
        }
    }
}
