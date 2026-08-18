
using LiteBus.Queries.Abstractions;

namespace Store.Features.Products.GetDetail
{
    public record GetProductDetailQuery(int Id) : IQuery<ProductDetailDto>;
}