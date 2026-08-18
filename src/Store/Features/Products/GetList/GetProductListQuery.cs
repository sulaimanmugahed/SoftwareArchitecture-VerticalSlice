
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.GetList
{
    public record GetProductListQuery : IQuery<List<ProductDto>>;
}