using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Controllers
{
    public class ShopController : Controller
    {

        private readonly MiniStoreContext _context;

        public ShopController(MiniStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var mCount = _context.Minis.Count();
            indexViewModel i = new indexViewModel { IsPainted = false, IsFiltered = false, IsLuminous = false, TotalCount = mCount };

            return View(i);
        }


        [HttpPost]
        public async Task<IActionResult> Index(indexViewModel i)
        {
            if (i.IsLuminous)
                i.IsFiltered = true;
            if (i.IsPainted)
                i.IsFiltered = true;
            if (i.MinPrice != 0D)
                i.IsFiltered = true;
            if (i.MaxPrice != 1000D)
                i.IsFiltered = true;
            return View(i);
        }




        public IActionResult Item()
        {
            return View();
        }
    }
}
