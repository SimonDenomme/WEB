using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.Models
{
    public record ProduitDetails(int Id, string Name, string ImagePath,
                                    double NormalPrice, double ReducedPrice);

    public record ProduitList(params ProduitDetails[] ProduitDetails);
}
