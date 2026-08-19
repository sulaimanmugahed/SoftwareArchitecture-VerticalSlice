using LiteBus.Commands.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Features.Products.Buy
{
    public class BuyProductCommandHandler(
          AppDbContext dbContext
    ) : ICommandHandler<BuyProductCommand>
    {
        public async Task HandleAsync(BuyProductCommand message, CancellationToken cancellationToken = default)
        {
            var input = message.Input;

            // retrieve entities from database to execute the operation
            var customer = await dbContext.Customers.FindAsync(input.CustomerId);
            if (customer is null)
            {
                throw new KeyNotFoundException($"no customer exist with this is: {input.CustomerId}");
            }

            var product = await dbContext.Products.FindAsync(input.ProductId);
            if (product is null)
            {
                throw new KeyNotFoundException($"no product exist with this is: {input.ProductId}");
            }

            // execute domain business
            var totalPrice = product.GetTotalPrice(input.Quantity);
            customer.ReduceBalance(totalPrice);
            product.DecreaseQuantity(input.Quantity);

            // save changes
            await dbContext.SaveChangesAsync();

            //here i can send email or sms
        }
    }

}