﻿namespace MiniStore.Entity
{
    public class Mini
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Cost { get; set; }
        public double Discount { get; set; }
    }
}
