using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Command
{
    public class CommandInfos
    {
        public Guid Id { get; set; }

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
        public CartViewModels.CartViewModel Cart { get; set; }

        // Infos Command
        public double FraisLivraison { get; set; }
    }
}
