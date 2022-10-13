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
            var mini =  _context.Minis.Where(m => m.Id == Id).Select(m => new ProduitDetails(Id,
                                                        m.Name, m.ImagePath,
                                                        m.NormalPrice, m.ReducedPrice)).FirstOrDefault();

            var minis = _context.Minis.Where(m => m.Id == Id)
                .Select(mi => new MinisDetails(Id, mi.Description, mi.Reviews, mi.StatusId,mini));


            return View(new MinisNotList(minis.ToArray()));
        }
    }
}
