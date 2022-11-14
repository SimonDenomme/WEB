using System;

namespace MiniStore.Domain
{
    // Table Many Many entre cart et les minis
    public class ItemInCart
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }


        // Navigations Properties
        public Guid MiniId { get; set; }
        public Mini Mini { get; set; }
        public Guid? CartId { get; set; }
        public Guid? CommandeId { get; set; } = null;    // ForeignKey
    }
}
