using System.Collections.Generic;

namespace MiniStore.Entity
{
    public class Mini
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsColored { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        //public int QtyInventory { get; set; }
        //public int QtySold { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
