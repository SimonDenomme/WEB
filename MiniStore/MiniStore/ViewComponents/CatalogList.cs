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
    public class CatalogList : ViewComponent
    {
        private readonly MiniStoreContext _context;


        public CatalogList(MiniStoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            bool IsPainted = true,
            bool IsLuminous = true)
        {

            //if (false)
            //{
            //    var minis = _context.Minis.ToList()
            //            .Where(m => (m.IsLuminous == IsLuminous && m.IsPainted == IsPainted))
            //            .Select(m => new ProduitDetails(m.Id,
            //                                                m.Name, m.ImagePath,
            //                                                m.NormalPrice, m.ReducedPrice));
            //    return View(new ProduitList(minis.ToArray()));

            //}
            //else
            //{
                var minis = _context.Minis.ToList()
                        .Select(m => new ProduitDetails(m.Id,
                                                                m.Name, m.ImagePath,
                                                                m.NormalPrice, m.ReducedPrice));
                return View(new ProduitList(minis.ToArray()));
           // }
        }

        //private Task<List<Minis>> GetMinisAsync()
        //{
        //    var minis =  _context.Minis.Where(mini => mini.StatusId != 1).ToListAsync();



        //}


    }
}
