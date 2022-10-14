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
            bool IsFiltered = false,
            double MinPrice = 0D,
            double MaxPrice = 1000D,
            _OrderBy _Order = _OrderBy.AtoZ)
        {

            if (IsFiltered)
            {
                //var minis = _context.Minis.ToList();

                var minis = _context.Minis.ToList()
                        .Where(m => m.IsLuminous == IsLuminous &&
                                                 m.IsPainted == IsPainted &&
                                                 m.NormalPrice >= MinPrice &&
                                                 m.NormalPrice <= MaxPrice)
                        .Select(m => new ProduitDetails(m.Id,
                                                        m.Name, m.ImagePath,
                                                        m.NormalPrice, m.ReducedPrice));

                if (_Order == _OrderBy.ZtoA)
                {
                    minis = minis.OrderByDescending(m => m.Name);

                    return View(new ProduitList(minis.ToArray()));
                }
                else if (_Order == _OrderBy.PriceUp)
                {
                    minis = minis.OrderBy(m => m.NormalPrice);

                    return View(new ProduitList(minis.ToArray()));
                }
                else if (_Order == _OrderBy.PriceDown)
                {
                    minis = minis.OrderByDescending(m => m.NormalPrice);

                    return View(new ProduitList(minis.ToArray()));
                }
                else
                {
                    minis = minis.OrderBy(m => m.Name);

                    return View(new ProduitList(minis.ToArray()));
                }
            }
            else
            {
                var minis = _context.Minis.ToList()
                        .Select(m => new ProduitDetails(m.Id,
                                                                m.Name, m.ImagePath,
                                                                m.NormalPrice, m.ReducedPrice));
                if (_Order == _OrderBy.ZtoA)
                {
                    minis = minis.OrderByDescending(m => m.Name);

                    return View(new ProduitList(minis.ToArray()));
                }
                else if (_Order == _OrderBy.PriceUp)
                {
                    minis = minis.OrderBy(m => m.NormalPrice);

                    return View(new ProduitList(minis.ToArray()));
                }
                else if (_Order == _OrderBy.PriceDown)
                {
                    minis = minis.OrderByDescending(m => m.NormalPrice);

                    return View(new ProduitList(minis.ToArray()));
                }
                else
                {
                    minis = minis.OrderBy(m => m.Name);

                    return View(new ProduitList(minis.ToArray()));
                }
                //return View(new ProduitList(minis.ToArray()));
            }
        }
    }
}
