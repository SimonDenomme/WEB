namespace MiniStore.Domain
{
    public class Commande
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public bool IsSent { get; set; } = false;
        // Navigation properties
        public Cart Items { get; set; }

    }
}
