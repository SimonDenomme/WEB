using MiniStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal TotalAvantTaxe { get; set; }
        public decimal Taxe { get; set; }
        public decimal TotalApresTaxe { get; set; }
        public decimal FraisLivraison { get; set; }


        public List<ItemInCart> Items { get; set; }
    }
}
