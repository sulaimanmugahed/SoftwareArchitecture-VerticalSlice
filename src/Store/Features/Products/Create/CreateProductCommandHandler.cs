
using LiteBus.Commands.Abstractions;
using Store.Common.Persistence;
using Store.Domain;


namespace Store.Features.Products.Create
{
    public class CreateProductCommandHandler(
       AppDbContext dbContext
    ) : ICommandHandler<CreateProductCommand, int>
    {
        public async Task<int> HandleAsync(CreateProductCommand message, CancellationToken cancellationToken = default)
        {
            var input = message.Input;

            var existCategory = await dbContext.Categories.FindAsync(input.CategoryId);
            if (existCategory is null)
            {
                throw new KeyNotFoundException($"no category exist with this is: {input.CategoryId}");
            }

            var productToAdd = Product.Create(input.Name, input.Price, input.CategoryId);

            var addedProduct = await dbContext.Products.AddAsync(productToAdd);
            await dbContext.SaveChangesAsync();

            return addedProduct.Entity.Id;
        }
    }

}