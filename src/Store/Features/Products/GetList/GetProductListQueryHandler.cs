using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Common.Persistence;


namespace Store.Features.Products.GetList
{
    public class GetProductListQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetProductListQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> HandleAsync(GetProductListQuery message, CancellationToken cancellationToken = default)
        {
            var products = await dbContext.Products.ToListAsync();

            return products.Select(p =>
            new ProductDto(p.Id, p.Name, p.Price, p.Quantity))
            .ToList();
        }
    }
}