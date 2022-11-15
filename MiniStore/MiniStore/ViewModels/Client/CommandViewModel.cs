using MiniStore.ViewModels.Cart;
using System;

namespace MiniStore.ViewModels.Client
{
    public class CommandViewModel
    {
        public Guid Id { get; set; }
        public CartViewModels.CartViewModel Items { get; set; }
        public string Status { get; set; }
    }
}
