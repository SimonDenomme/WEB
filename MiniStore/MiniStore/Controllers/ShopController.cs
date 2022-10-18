using Microsoft.AspNetCore.Mvc;
using MiniStore.Data;
using MiniStore.Models;
using System.Linq;
using System.Threading.Tasks;
using MiniStore.Entity;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        public IActionResult Search(string search)
        {
            var minis = _context.Minis.Where(m => m.Name.Contains(search)).ToList();
            var miniSize = _context.Sizes.ToList();
            var miniFini = minis.Select(m => new ProduitDetails(m.Id, m.Name, m.ImagePath, miniSize.Where(s => s.Id == m.SizeId).FirstOrDefault().Title, m.NormalPrice, m.ReducedPrice, m.StatusId)).ToList();
            ProduitList p = new ProduitList(miniFini.ToArray());
            return View("Index", p);
        }
        
        [Authorize]
        public IActionResult AdminProduit() { return View(); }

        [Authorize]
        public IActionResult SupprimerProduit() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SupprimerProduit(int id)
        {
            var mini = _context.Minis.Where(i => i.Id == id).FirstOrDefault();
            _context.Minis.Remove(mini);
            await _context.SaveChangesAsync();
            return SupprimerProduit();
        }
        [Authorize]
        public IActionResult ModifierProduit(int id)
        {
            //var mini = _context.Minis.Where(i => i.Id == id).FirstOrDefault();
            var mini = _context.Minis.Take(id);
            //_context.Minis.Remove(mini);
            return View("MiniModification", mini);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ModifierProduit(Mini mini)
        {
            try
            {
                //var mini1 = _context.Minis.Take(mini.Id);
                var mini1 = _context.Minis.Where(i => i.Id == mini.Id).FirstOrDefault();
                mini1 = mini;
                _context.Update(mini);
                await _context.SaveChangesAsync();
                return AdminProduit();
            }
            catch
            {
                return StatusCode(500, "Server error");
            }
        }
        [Authorize]
        public IActionResult AjouterProduit() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AjouterProduit(Mini mini)
        {
            //var mini1 = _context.Minis.Where(i => i.Id == mini.Id).FirstOrDefault();
            _context.Minis.Add(mini);
            await _context.SaveChangesAsync();
            return AjouterProduit();
        }
        public IActionResult Item() { return View(); }

    }
}
