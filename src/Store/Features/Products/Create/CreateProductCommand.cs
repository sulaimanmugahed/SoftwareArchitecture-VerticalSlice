
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Create
{
    public record CreateProductCommand(CreateProductInput Input) : ICommand<int>;

}