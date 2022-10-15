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
            bool IsPainted = false,
            bool IsLuminous = false,
            bool FiltreA = false,
            bool FiltreB = false,
            bool FiltreC = false,
            bool IsFiltered = false,
            double MinPrice = 0D,
            double MaxPrice = 1000D,
            _OrderBy _Order = _OrderBy.AtoZ,
            int StatusId = 1,
            int PageIndex = 1,
            int TotalPage = 1)
        {

            IEnumerable<ProduitDetails> miniFini;
            var minis1 = _context.Minis.ToList();

            if (_Order == _OrderBy.ZtoA)
                minis1 = minis1.OrderByDescending(m => m.Name).ToList();
            else if (_Order == _OrderBy.PriceUp)
                minis1 = minis1.OrderBy(m => m.NormalPrice).ToList();
            else if (_Order == _OrderBy.PriceDown)
                minis1 = minis1.OrderByDescending(m => m.NormalPrice).ToList();
            else
                minis1 = minis1.OrderBy(m => m.Name).ToList();

            if (IsFiltered)
            {
                if (FiltreA)
                    minis1 = minis1.Where(m => m.IsLuminous == IsLuminous &&
                                                 m.IsPainted == IsPainted).ToList();
                if (FiltreB)
                    minis1 = minis1.Where(m => m.NormalPrice >= MinPrice &&
                                                 m.NormalPrice <= MaxPrice).ToList();
                if (FiltreC && StatusId != 1)
                    minis1 = minis1.Where(m => m.StatusId == StatusId).ToList();
            }




            miniFini = minis1.Select(m => new ProduitDetails(m.Id,
                                                    m.Name, m.ImagePath,
                                                    m.NormalPrice, m.ReducedPrice, m.StatusId)).Skip((PageIndex - 1) * 30).Take(30);


            return View(new ProduitList(miniFini.ToArray()));
        }
    }
}
//else
//{
//    var minis = _context.Minis.ToList()
//            .Select(m => new ProduitDetails(m.Id,
//                                                    m.Name, m.ImagePath,
//                                                    m.NormalPrice, m.ReducedPrice));
//    if (_Order == _OrderBy.ZtoA)
//    {
//        minis = minis.OrderByDescending(m => m.Name);

//        return View(new ProduitList(minis.ToArray()));
//    }
//    else if (_Order == _OrderBy.PriceUp)
//    {
//        minis = minis.OrderBy(m => m.NormalPrice);

//        return View(new ProduitList(minis.ToArray()));
//    }
//    else if (_Order == _OrderBy.PriceDown)
//    {
//        minis = minis.OrderByDescending(m => m.NormalPrice);

//        return View(new ProduitList(minis.ToArray()));
//    }
//    else
//    {
//        minis = minis.OrderBy(m => m.Name);

//        return View(new ProduitList(minis.ToArray()));
//    }
//}