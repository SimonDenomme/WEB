using System;
using System.Collections.Generic;

namespace MiniStore.ViewModels.Cart
{
    public class CartViewModels
    {
        public record ItemInCartModel(Guid Id, string Name, string ImagePath, int Quantity, double Price);
        public record CartViewModel(Guid Id, string UserName, List<ItemInCartModel> ItemsInCart, double SousTotal, double Taxes, double Total);
    }
}
                                         