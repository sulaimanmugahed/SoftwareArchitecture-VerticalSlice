
using LiteBus.Queries.Abstractions;

namespace Store.Features.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryListItemDto>>;
}