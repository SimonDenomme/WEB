using MiniStore.ViewModels.Cart;
using System;

namespace MiniStore.ViewModels.Command
{
    public class BillViewModel
    {
        public string CommandId { get; set; }
        public string CommandStatus { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CreditCard { get; set; }
        public string Date { get; set; }

        public CartViewModels.CartViewModel Items { get; set; }
    }
}
