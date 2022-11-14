using System;
using System.Collections.Generic;

namespace MiniStore.Domain
{
    public class Cart
    {
        public Guid Id { get; set; }

        public bool IsCommand { get; set; } = false;

        // Navigation properties
        public List<ItemInCart> items { get; set; }
        public string UserId { get; set; }
        public ApplicationUser CartUser { get; set; }
    }
}
