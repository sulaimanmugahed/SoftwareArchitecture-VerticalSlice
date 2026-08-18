using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Common.Persistence;


namespace Store.Features.Categories.GetList
{
    public class GetCategoryListQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> HandleAsync(GetCategoryListQuery message, CancellationToken cancellationToken = default)
        {
            return await dbContext.Categories
            .Select(c => new CategoryDto(c.Id, c.Name))
            .ToListAsync();
        }
    }
}