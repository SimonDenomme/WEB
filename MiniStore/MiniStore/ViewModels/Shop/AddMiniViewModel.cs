using System.Diagnostics;

namespace MiniStore.ViewModels.Shop
{
    public class AddMiniViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsPainted { get; set; }
        public bool IsLuminous { get; set; }
        public int QtyInventory { get; set; }
        public double Normalprice { get; set; }
        public double ReducedPrice { get; set; }


        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        //public int StatusId { get; set; }         // Normalement c'est une donnée qui est gérée par le site, pas par l'utilisateur
    }
}
                                                