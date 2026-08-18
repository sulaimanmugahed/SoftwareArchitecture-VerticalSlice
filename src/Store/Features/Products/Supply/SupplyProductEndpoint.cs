
using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Supply
{
    public class SupplyProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products/supply", async (SupplyProductInput input, ICommandMediator mediator) =>
            {
                await mediator.SendAsync(new SupplyProductCommand(input));
                return Results.Ok();
            }).WithTags("Products");
        }
    }
}