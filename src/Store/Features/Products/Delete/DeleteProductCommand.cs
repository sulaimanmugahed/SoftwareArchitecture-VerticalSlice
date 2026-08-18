
using LiteBus.Commands.Abstractions;

namespace Store.Features.Products.Delete
{
    public record DeleteProductCommand(int Id) : ICommand;
}