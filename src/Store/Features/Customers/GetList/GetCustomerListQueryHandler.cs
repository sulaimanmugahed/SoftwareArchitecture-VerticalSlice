using LiteBus.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using Store.Common.Persistence;

namespace Store.Features.Customers.GetList
{
    public class GetCustomerListQueryHandler(
        AppDbContext dbContext
    ) : IQueryHandler<GetCustomerListQuery, List<CustomerDto>>
    {
        public async Task<List<CustomerDto>> HandleAsync(GetCustomerListQuery message, CancellationToken cancellationToken = default)
        {
            var customers = await dbContext.Customers.ToListAsync();
            return customers.Select(c => new CustomerDto(c.Id, c.Name, c.Balance))
            .ToList();
        }
    }
}