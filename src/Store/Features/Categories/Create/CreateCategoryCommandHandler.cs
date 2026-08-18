
using LiteBus.Commands.Abstractions;
using Store.Common.Persistence;
using Store.Domain;


namespace Store.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(
        AppDbContext dbContext
    ) : ICommandHandler<CreateCategoryCommand, int>
    {
        public async Task<int> HandleAsync(CreateCategoryCommand message, CancellationToken cancellationToken = default)
        {
            var input = message.Input;

            var categoryToAdd = Category.Create(input.Name);

            var addedCategory = await dbContext.Categories.AddAsync(categoryToAdd);
            await dbContext.SaveChangesAsync();

            return addedCategory.Entity.Id;
        }
    }
}