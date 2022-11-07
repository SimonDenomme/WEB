namespace MiniStore.Domain
{
    public class Commande
    {
        public int Id { get; set; }

        // Navigation properties
        public Cart Items { get; set; }

    }
}
