

using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Buy
{
    public class BuyProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products/buy", async (ICommandMediator mediator, BuyProductInput input) =>
            {
                await mediator.SendAsync(new BuyProductCommand(input));
                return Results.Ok();
            }).WithTags("Products");
        }
    }
}