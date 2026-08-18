

using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Categories.Get
{
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