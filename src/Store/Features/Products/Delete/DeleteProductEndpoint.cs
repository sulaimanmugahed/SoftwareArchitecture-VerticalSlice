

using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Delete
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (int id, ICommandMediator mediator) =>
            {
                await mediator.SendAsync(new DeleteProductCommand(id));
                return Results.Ok();
            }).WithTags("Products");
        }
    }
}