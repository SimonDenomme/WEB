namespace MiniStore.Domain
{
    public class Commande
    {
        public int Id { get; set; }                 // PK
        public string UserId { get; set; }          // Foreign Key
        public bool IsSent { get; set; } = false;   // Pour qu'il n'apparaisse pas dans la liste des commandes à envoyer
        // Navigation properties
        public int AddressId { get; set; }          // Foreign Key
        public Address Address { get; set; }        // Propriété de navigation probable
        public Cart Items { get; set; }             // C'est l'équivalent un peu éclaté de faire List<ItemInCart>
    }
}
