namespace MiniStore.Entity
{
    public class Mini
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
    }
}
