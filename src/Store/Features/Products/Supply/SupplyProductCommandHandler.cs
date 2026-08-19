
using LiteBus.Commands.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Features.Products.Supply
{
    public class SupplyProductCommandHandler(
      AppDbContext dbContext
  ) : ICommandHandler<SupplyProductCommand>
    {
        public async Task HandleAsync(SupplyProductCommand message, CancellationToken cancellationToken = default)
        {
            var input = message.Input;

            var product = await dbContext.Products.FindAsync(input.ProductId);
            if (product is null)
            {
                throw new KeyNotFoundException($"no product exist with this is: {input.ProductId}");
            }

            product.ReStock(input.Quantity);

            await dbContext.SaveChangesAsync();
        }
    }
}

