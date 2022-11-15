using MiniStore.ViewModels.Cart;
using System;

namespace MiniStore.ViewModels.Command
{
    public class CommandInfos
    {
        public Guid Id { get; set; }
        public bool IsPaid { get; set; }

        // Infos Clients
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }

        // Address
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Cart
        public CartViewModels.CartViewModel Items { get; set; }

        // Infos Command
        public double FraisLivraison { get; set; }
    }
}
