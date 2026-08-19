using LiteBus.Queries.Abstractions;
using Store.Infrastructure.Persistence;


namespace Store.Features.Categories.Get
{
    public class GetCategoryQueryHandler(
     AppDbContext dbContext
    ) : IQueryHandler<GetCategoryQuery, CategoryDto>
    {
        public async Task<CategoryDto> HandleAsync(GetCategoryQuery message, CancellationToken cancellationToken = default)
        {
            var category = await dbContext.Categories.FindAsync(message.Id);
            if (category is null)
            {
                throw new KeyNotFoundException($"no category exist with this is: {message.Id}");
            }

            return new CategoryDto(category.Id, category.Name);
        }
    }
}