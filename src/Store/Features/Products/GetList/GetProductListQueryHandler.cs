using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;


namespace Store.Features.Products.GetList
{
    public class GetProductListQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetProductListQuery, List<ProductListItemDto>>
    {
        public async Task<List<ProductListItemDto>> HandleAsync(GetProductListQuery message, CancellationToken cancellationToken = default)
        {
            var products = await dbContext.Products.ToListAsync();

            return products.Select(p =>
            new ProductListItemDto(p.Id, p.Name, p.Price, p.Quantity))
            .ToList();
        }
    }
}