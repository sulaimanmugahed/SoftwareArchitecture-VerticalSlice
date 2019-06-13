using Carter;
using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CategoryListItemDto(
     int Id,
     string Name
    );

    public record GetCategoryListQuery : IQuery<List<CategoryListItemDto>>;

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

    public class GetCategoryListEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories", async (IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetCategoryListQuery()));
            }).WithTags("Categories");
        }
    }

}