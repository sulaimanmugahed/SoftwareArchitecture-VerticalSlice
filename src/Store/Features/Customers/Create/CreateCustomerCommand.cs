
using LiteBus.Commands.Abstractions;

namespace Store.Features.Customers.Create
{
    public record CreateCustomerCommand(CreateCustomerInput Input) : ICommand<int>;

}