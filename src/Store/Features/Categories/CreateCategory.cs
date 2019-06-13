using Carter;
using FluentValidation;
using LiteBus.Commands.Abstractions;
using Store.Domain;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CreateCategoryInput(
    string Name
   );
    public record CreateCategoryCommand(CreateCategoryInput Input) : ICommand<int>;

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Input)
            .NotEmpty().WithMessage("Create Input is required.")
            .ChildRules(input =>
            {
                input.RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Category name cant be null or empty");
            });
        }
    }

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

    public class CreateCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/categories", async (CreateCategoryInput input, ICommandMediator mediator) =>
            {
                return Results.Ok(await mediator.SendAsync(new CreateCategoryCommand(input)));
            }).WithTags("Categories");
        }
    }



}