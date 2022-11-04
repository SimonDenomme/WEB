using System.Collections.Generic;

namespace MiniStore.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // ToDo: Il faut avoir un moyen de garder à quel user le panier est (UserID, UserName, ...)
        public string UserName { get; set; }

        // ToDo: Gestion de la cardinalité entre Cart et Mini
        public List<ItemInCart> Items { get; set; }

    }
}
