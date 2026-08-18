
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Buy
{
    public record BuyProductCommand(BuyProductInput Input) : ICommand;

}