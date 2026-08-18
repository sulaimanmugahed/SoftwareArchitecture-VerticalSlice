
using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.GetList
{
    public class GetProductListEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetProductListQuery()));
            }).WithTags("Products");
        }
    }
}