

using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.Get
{
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (int id, IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetProductQuery(id)));
            }).WithTags("Products");
        }
    }
}