

using Carter;
using LiteBus.Queries.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CategoryDto(
    int Id,
    string Name
    );

    /////

    public record GetCategoryQuery(int Id) : IQuery<CategoryDto>;

    /////

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

    /////

    public class GetCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories/{id}", async (int id, IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetCategoryQuery(id)));
            }).WithTags("Categories");
        }
    }
}