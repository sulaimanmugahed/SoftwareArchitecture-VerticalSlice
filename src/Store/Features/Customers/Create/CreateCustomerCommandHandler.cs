using LiteBus.Commands.Abstractions;
using Store.Infrastructure.Persistence;
using Store.Domain;


namespace Store.Features.Customers.Create
{
    public class CreateCustomerCommandHandler(
        AppDbContext dbContext
    ) : ICommandHandler<CreateCustomerCommand, int>
    {
        public async Task<int> HandleAsync(CreateCustomerCommand message, CancellationToken cancellationToken = default)
        {
            var input = message.Input;

            var customerToAdd = Customer.Create(input.Name, input.Balance);

            var addedCustomer = await dbContext.Customers.AddAsync(customerToAdd);
            await dbContext.SaveChangesAsync();

            return addedCustomer.Entity.Id;
        }
    }

}