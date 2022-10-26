namespace MiniStore.ViewModels.Shop
{
    public class EditMiniViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsPainted { get; set; }
        public bool IsLuminous { get; set; }
        public int QtyInventory { get; set; }
        public double NormalPrice { get; set; }
        public double ReducedPrice { get; set; }
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
    }
}
