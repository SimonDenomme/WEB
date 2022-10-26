﻿using System.Diagnostics;

namespace MiniStore.ViewModels.Shop
{
    public class MiniViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double NormalPrice { get; set; }
        public double ReducedPrice { get; set; }

    }
}