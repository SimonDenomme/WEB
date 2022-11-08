using MiniStore.Domain;
using System.Collections.Generic;

namespace MiniStore.Models
{
    public class ClientViewModel
    {
        public ApplicationUser User { get; set; }

        //public string Name { get; set; }

        public List<Commande> Commands { get; set; }

    }
}
