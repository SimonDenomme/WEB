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

        public async Task<IViewComponentResult> InvokeAsync()
        {

            //// a modifier
            //var minis = await _context.Minis.Where(mini => mini.StatusId != 1).ToListAsync();
            ////var minisModel = _context.MinisModel.
            //foreach (var item in minis)
            //{

            //    if (!_context.MinisModel.Where(m => m.Id == item.Id).Any())
            //    {

            //        var Add = new Minis
            //        {
            //            Id = item.Id,
            //            ImagePath = item.ImagePath,
            //            Name = item.Name,
            //            NormalPrice = item.NormalPrice,
            //            ReducedPrice = item.ReducedPrice,
            //        };
            //        _context.MinisModel.Add(Add);
            //        _context.SaveChanges();
            //    }
            //}
            //var model_mini = _context.MinisModel.AsAsyncEnumerable();


            var minis = _context.Minis.ToList()
                    .Select(m => new ProduitDetails(m.Id,
                                                        m.Name, m.ImagePath,
                                                        m.NormalPrice, m.ReducedPrice));
            
            return View(new ProduitList(minis.ToArray()));
        }

        //private Task<List<Minis>> GetMinisAsync()
        //{
        //    var minis =  _context.Minis.Where(mini => mini.StatusId != 1).ToListAsync();



        //}


    }
}
