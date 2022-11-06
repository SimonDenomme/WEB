using System.Collections.Generic;

namespace MiniStore.Domain
{
    public class Cart
    {
        public int Id { get; set; }

        public bool IsCommand { get; set; }

        // Navigation properties
        public List<ItemInCart> items { get; set; }
        public string UserId { get; set; }
        public ApplicationUser CartUser { get; set; }
    }
}
