using Carter;
using FluentValidation;
using LiteBus.Commands.Abstractions;
using Store.Domain;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CreateCustomerInput(
       string Name,
       decimal Balance
       );
    public record CreateCustomerCommand(CreateCustomerInput Input) : ICommand<int>;

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Input)
            .NotEmpty().WithMessage("Create Input is required.")
            .ChildRules(input =>
            {
                input.RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Customer name cant be null or empty");
            });
        }
    }

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

    public class CreateCustomerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/customers", async (CreateCustomerInput input, ICommandMediator mediator) =>
            {
                return Results.Ok(await mediator.SendAsync(new CreateCustomerCommand(input)));
            }).WithTags("Customers");
        }
    }



}