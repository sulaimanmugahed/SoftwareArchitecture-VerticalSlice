
using LiteBus.Queries.Abstractions;

namespace Store.Features.Customers.GetList
{
    public record GetCustomerListQuery : IQuery<List<CustomerDto>>;
}