

namespace Store.Features.Products.Get
{
    public record ProductDto(
        int Id,
        string Name,
        decimal Price,
        int Quantity);
}