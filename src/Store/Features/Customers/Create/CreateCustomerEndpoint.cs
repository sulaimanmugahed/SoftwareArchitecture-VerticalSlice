using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Customers.Create
{

    public class CreateCustomerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/customers", async (CreateCustomerInput input, ICommandMediator mediator) =>
            {
                return Results.Ok(await mediator.SendAsync(new CreateCustomerCommand(input)));
            }).WithTags("Customers");
        }
    }

}