using MiniStore.Domain;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }  //pas une bonne idee de là'exposer ici je pense
        public bool IsSent { get; set; } = false;   //utilisé pour le statut annulée ou pas

        // Address
        public int AddressId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Cart ?
        public Cart Cart { get; set; }
    }
}
