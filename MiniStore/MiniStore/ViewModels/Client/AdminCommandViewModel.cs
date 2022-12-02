using MiniStore.ViewModels.Cart;
using System;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Client
{
    public class AdminCommandViewModel
    {
        public string UserName { get; set; }
        public List<CommandViewModel> Commandes { get; set; }
    }
}
