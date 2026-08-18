

namespace Store.Features.Products.Create
{
    public record CreateProductInput(
        string Name,
        decimal Price,
        int CategoryId
    );
}