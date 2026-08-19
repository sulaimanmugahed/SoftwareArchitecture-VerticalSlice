using LiteBus.Queries.Abstractions;
using Store.Infrastructure.Persistence;


namespace Store.Features.Customers.Get
{
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
}