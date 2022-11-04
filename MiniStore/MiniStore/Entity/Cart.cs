using MiniStore.Domain;
using System.Collections.Generic;

namespace MiniStore.Entity
{
    public class Cart
    {
        public int Id { get; set; }

        // Navigation properties
        public List<ItemInCart> items { get; set; }
        public string UserId { get; set; }
        public ApplicationUser CartUser { get; set; }
    }
}
