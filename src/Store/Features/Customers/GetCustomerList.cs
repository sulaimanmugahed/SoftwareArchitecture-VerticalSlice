using Carter;
using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CustomerListItemDto(
       int Id,
       string Name,
       decimal Balance
   );

    public record GetCustomerListQuery : IQuery<List<CustomerListItemDto>>;

    public class GetCustomerListQueryHandler(
      AppDbContext dbContext
  ) : IQueryHandler<GetCustomerListQuery, List<CustomerListItemDto>>
    {
        public async Task<List<CustomerListItemDto>> HandleAsync(GetCustomerListQuery message, CancellationToken cancellationToken = default)
        {
            var customers = await dbContext.Customers.ToListAsync();
            return customers.Select(c => new CustomerListItemDto(c.Id, c.Name, c.Balance))
            .ToList();
        }
    }

    public class GetCustomerListEndpoint : ICarterModule
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