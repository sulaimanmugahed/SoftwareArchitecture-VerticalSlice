

namespace Store.Features.Products.GetList
{
    public record ProductListItemDto(
        int Id,
        string Name,
        decimal Price,
        int Quantity);
}