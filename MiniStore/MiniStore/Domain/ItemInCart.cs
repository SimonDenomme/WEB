namespace MiniStore.Domain
{
    // Table Many Many entre cart et les minis
    public class ItemInCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        // Navigations Properties
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int MiniId { get; set; }
        public Mini Mini { get; set; }
    }
}
