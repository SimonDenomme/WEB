using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Data;
using MiniStore.Models;


namespace MiniStore.ViewComponents
{
    public class InfoItemMini : ViewComponent
    {
        private readonly MiniStoreContext _context;

        public InfoItemMini(MiniStoreContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id = 1)
        {
            var size = _context.Sizes.Where(s => s.Id == Id).FirstOrDefault();

            var mini =  _context.Minis.Where(m => m.Id == Id).Select(m => new ProduitDetails(Id,
                                                        m.Name, m.ImagePath, m.Size.Title,
                                                        m.NormalPrice, m.ReducedPrice, m.StatusId)).FirstOrDefault();

            var minis = _context.Minis.Where(m => m.Id == Id)
                .Select(mi => new MinisDetails(Id, mi.Description, mi.Reviews, mi.StatusId,mini));


            return View(new MinisNotList(minis.ToArray()));
        }
    }
}
