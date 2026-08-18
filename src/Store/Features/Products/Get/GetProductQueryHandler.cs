
using LiteBus.Queries.Abstractions;
using Store.Common.Persistence;

namespace Store.Features.Products.Get
{
    public class GetProductQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetProductQuery, ProductDto>
    {
        public async Task<ProductDto> HandleAsync(GetProductQuery message, CancellationToken cancellationToken = default)
        {
            var product = await dbContext.Products.FindAsync(message.Id);
            if (product is null)
            {
                throw new KeyNotFoundException($"no product exist with this is: {message.Id}");
            }

            return new ProductDto(product.Id, product.Name, product.Price, product.Quantity);
        }
    }
}