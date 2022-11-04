﻿using System;
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
            var m = await _context.Minis.FindAsync(Id);

            return View(
                new MinisDetails(
                    Id, m.ImagePath, m.Name, m.Description,
                    m.NormalPrice, 1, m.Reviews, m.StatusId));
        }
    }
}
