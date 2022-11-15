using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.Domain;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public Guid Id { get; set; }
        public bool IsSent { get; set; }

        // Address
        public int AddressId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // DropDownList pour les adresses
        public IEnumerable<SelectListItem> Addresses { get; set; }
        public string SelectedAddress { get; set; }

        // Je suis moins sur de ceux qui suive (je = Simon)
        public Address Adresse { get; set; }
        public CartViewModels.CartViewModel Cart { get; set; }
        public List<ItemInCart> Items { get; set; }
        public ApplicationUser CommandUser { get; set; }
    }
}
