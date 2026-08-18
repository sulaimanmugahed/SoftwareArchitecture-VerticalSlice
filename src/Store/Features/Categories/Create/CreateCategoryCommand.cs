
using LiteBus.Commands.Abstractions;

namespace Store.Features.Categories.Create
{
    public record CreateCategoryCommand(CreateCategoryInput Input) : ICommand<int>;
}