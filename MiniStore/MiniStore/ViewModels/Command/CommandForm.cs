using Microsoft.AspNetCore.Mvc.Rendering;
using MiniStore.ViewModels.Cart;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Command
{
    public class CommandForm
    {
        public int Id { get; set; }

        // DropDownList pour les adresses
        public IEnumerable<SelectListItem> Addresses { get; set; }
        public string SelectedAddress { get; set; }

        // Address
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // Cart
        public CartViewModels.CartViewModel Cart { get; set; }
    }
}
