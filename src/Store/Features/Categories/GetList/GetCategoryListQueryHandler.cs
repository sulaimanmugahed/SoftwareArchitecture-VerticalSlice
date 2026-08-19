using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;


namespace Store.Features.Categories.GetList
{
    public class GetCategoryListQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetCategoryListQuery, List<CategoryListItemDto>>
    {
        public async Task<List<CategoryListItemDto>> HandleAsync(GetCategoryListQuery message, CancellationToken cancellationToken = default)
        {
            return await dbContext.Categories
            .Select(c => new CategoryListItemDto(c.Id, c.Name))
            .ToListAsync();
        }
    }
}