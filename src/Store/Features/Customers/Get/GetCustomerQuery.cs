
using LiteBus.Queries.Abstractions;

namespace Store.Features.Customers.Get
{
    public record GetCustomerQuery(int Id) : IQuery<CustomerDto>;
}