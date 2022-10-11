using Microsoft.AspNetCore.Mvc;

namespace MiniStore.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Item()
        {
            return View();
        }
    }
}
