

using Carter;
using LiteBus.Queries.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CustomerDto(
        int Id,
       string Name,
       decimal Balance
   );

    /////

    public record GetCustomerQuery(int Id) : IQuery<CustomerDto>;

    /////

    public class GetCustomerQueryHandler(
    AppDbContext dbContext
   ) : IQueryHandler<GetCustomerQuery, CustomerDto>
    {
        public async Task<CustomerDto> HandleAsync(GetCustomerQuery message, CancellationToken cancellationToken = default)
        {
            var customer = await dbContext.Customers.FindAsync(message.Id);
            if (customer is null)
            {
                throw new KeyNotFoundException($"no customer exist with this is: {message.Id}");
            }

            return new CustomerDto(
               customer.Id,
               customer.Name,
               customer.Balance);
        }
    }

    /////

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