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
            decimal mCount = _context.Minis.Count();
            decimal mpa = mCount / 30;
            int TP = (int)mpa;
            mpa = mpa % 1;
            if (mpa > 0)
                TP++;
            indexViewModel i = new indexViewModel { IsPainted = false, IsFiltered = false, IsLuminous = false, TotalCount = (int)mCount, PageIndex = 1, TotalPage = TP };

            return View(i);
        }


        [HttpPost]
        public async Task<IActionResult> Index(indexViewModel i)
        {
            
            if (i.FiltreA || i.FiltreB || i.FiltreC)
                i.IsFiltered = true;
            if (!i.FiltreA)
            {
                i.IsLuminous = false;
                i.IsPainted = false;
            }
            if (!i.FiltreB)
            {
                i.MinPrice = 0;
                i.MaxPrice = 1000;
            }
            if (!i.FiltreC)
            {
                i.StatusId = 1;
            }
            return View(i);
        }




        public IActionResult Item()
        {
            return View();
        }
    }
}
