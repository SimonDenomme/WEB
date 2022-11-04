﻿namespace MiniStore.Domain
{
    public class Command
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAvantTaxe { get; set; }
        public decimal Taxe { get; set; }
        public decimal TotalApresTaxe { get; set; }
        public decimal FraisLivraison { get; set; }

        // Navigation properties
        public Cart Items { get; set; }

    }
}
