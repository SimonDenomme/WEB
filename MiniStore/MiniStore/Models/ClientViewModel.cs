using MiniStore.Domain;
using System.Collections.Generic;

namespace MiniStore.Models
{
    public class ClientViewModel
    {
        //public ApplicationUser User { get; set; }

        public string UserName { get; set; }

        public List<Commande> Commands { get; set; }

    }
}
