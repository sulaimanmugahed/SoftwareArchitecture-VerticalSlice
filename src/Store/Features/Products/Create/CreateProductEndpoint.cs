

using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Create
{
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (ICommandMediator mediator, CreateProductInput input) =>
            {
                return Results.Ok(await mediator.SendAsync(new CreateProductCommand(input)));
            }).WithTags("Products");
        }
    }
}