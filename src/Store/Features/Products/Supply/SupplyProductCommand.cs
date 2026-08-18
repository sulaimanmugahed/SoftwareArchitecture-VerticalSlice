
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Supply
{
    public record SupplyProductCommand(SupplyProductInput Input) : ICommand;
}

