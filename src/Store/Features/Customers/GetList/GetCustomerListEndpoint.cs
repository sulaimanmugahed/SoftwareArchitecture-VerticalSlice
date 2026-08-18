using Carter;
using LiteBus.Queries.Abstractions;

namespace Store.Features.Customers.GetList
{

    public class GetCategoryListEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers", async (IQueryMediator mediator) =>
            {
                return Results.Ok(await mediator.QueryAsync(new GetCustomerListQuery()));
            }).WithTags("Customers");
        }
    }

}