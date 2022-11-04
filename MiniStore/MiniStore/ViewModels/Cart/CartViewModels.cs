﻿using System.Collections.Generic;

namespace MiniStore.ViewModels.Cart
{
    public class CartViewModels
    {
        public record ItemInCartModel(int Id, string Name, string ImagePath, int Quantity, double Price);
        public record CartViewModel(string UserName, IEnumerable<ItemInCartModel> ItemsInCart, double Price);
    }
}
                                         