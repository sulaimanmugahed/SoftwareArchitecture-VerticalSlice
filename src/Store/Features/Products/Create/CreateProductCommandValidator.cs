
using FluentValidation;

namespace Store.Features.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Input)
            .ChildRules(input =>
            {
                input.RuleFor(x => x.Name).NotNull().NotEmpty()
                .WithMessage("Product name cant be null or empty");

                input.RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be GreaterThan 0");
            });
        }
    }
}