using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Shop
{
    public class EditMiniViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsPainted { get; set; }
        public bool IsLuminous { get; set; }
        public int QtyInventory { get; set; }
        public double NormalPrice { get; set; }
        public double ReducedPrice { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public string SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Sizes { get; set; }
        public string SelectedSize { get; set; }

        public bool StatusIndiponible { get; set; }
    }
}
