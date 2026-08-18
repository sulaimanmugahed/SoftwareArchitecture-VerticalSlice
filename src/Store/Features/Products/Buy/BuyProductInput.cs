

namespace Store.Features.Products.Buy
{
    public record BuyProductInput(
        int ProductId,
        int CustomerId,
        int Quantity
    );
}