
using LiteBus.Queries.Abstractions;

namespace Store.Features.Categories.Get
{
    public record GetCategoryQuery(int Id) : IQuery<CategoryDto>;
}