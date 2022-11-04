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
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            // ToDo: Ajouter l'essentiel du formulaire pour le PanierItem
            var m = _context.Minis.FindAsync(Id);

            return View(
                new MinisDetails(
                    Id, m.Result.ImagePath, m.Result.Name, m.Result.Description,
                    m.Result.NormalPrice, 1, m.Result.Reviews, m.Result.StatusId));
        }
    }
}
