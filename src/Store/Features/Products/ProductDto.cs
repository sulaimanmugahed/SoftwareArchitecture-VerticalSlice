

namespace Store.Features.Products
{
    public record ProductDto(
        int Id,
        string Name,
        decimal Price,
        int Quantity);
}