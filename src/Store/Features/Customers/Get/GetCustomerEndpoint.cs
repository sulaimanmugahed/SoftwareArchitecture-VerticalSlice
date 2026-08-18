using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Customers.Get
{

    public class GetCustomerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers/{id}", async (int id, IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetCustomerQuery(id)));
            }).WithTags("Customers");
        }
    }
}