using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.Features.Customers.GetList
{
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
}