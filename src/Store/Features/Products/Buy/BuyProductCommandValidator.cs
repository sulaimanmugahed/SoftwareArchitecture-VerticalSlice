
using FluentValidation;

namespace Store.Features.Products.Buy
{
    public class BuyProductCommandValidator : AbstractValidator<BuyProductCommand>
    {
        public BuyProductCommandValidator()
        {
            RuleFor(library => library.Input)
          .NotEmpty().WithMessage("Buy Input is required.")
          .ChildRules(input =>
          {
              input.RuleFor(i => i.Quantity)
              .GreaterThan(0).WithMessage("Quantity must be GreaterThan 0");
          });


        }
    }
}