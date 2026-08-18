

namespace Store.Features.Products.GetDetail
{
    public record ProductDetailDto(
        int Id,
        string Name,
        decimal Price,
        int Quantity,
        string CategoryName);
}