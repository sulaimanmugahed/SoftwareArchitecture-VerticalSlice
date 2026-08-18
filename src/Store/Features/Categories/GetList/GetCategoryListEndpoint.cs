
using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Categories.GetList
{

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