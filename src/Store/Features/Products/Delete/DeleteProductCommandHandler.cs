
using LiteBus.Commands.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Features.Products.Delete
{
    public class DeleteProductCommandHandler(
       AppDbContext dbContext
    ) : ICommandHandler<DeleteProductCommand>
    {
        public async Task HandleAsync(DeleteProductCommand message, CancellationToken cancellationToken = default)
        {
            var productToDelete = await dbContext.Products.FindAsync(message.Id);
            if (productToDelete is null)
            {
                throw new KeyNotFoundException($"no product exist with this is: {message.Id}");
            }
            dbContext.Products.Remove(productToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}