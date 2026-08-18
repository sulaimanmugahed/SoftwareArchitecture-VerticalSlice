
using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.GetDetail
{
    public class GetProductDetailEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}/detail", async (int id, IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetProductDetailQuery(id)));
            }).WithTags("Products");
        }
    }
}