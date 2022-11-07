using MiniStore.Domain;
using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MiniStore.ViewModels.Cart.CartViewModels;

namespace MiniStore.Models
{
    public class CommandModel
    {
        public int Id { get; set; }

        public Cart Cart { get; set; }
        //public CartViewModel CVM { get; set; }
    }
}
