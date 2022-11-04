namespace MiniStore.Models
{
    public record ProduitDetails(int Id, string Name, string ImagePath, string Size,
                                    double NormalPrice, double ReducedPrice, int StatusId);

    public record ProduitList(params ProduitDetails[] ProduitDetails);
}
