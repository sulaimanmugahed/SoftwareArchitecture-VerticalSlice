
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.Get
{
    public record GetProductQuery(int Id) : IQuery<ProductDto>;
}