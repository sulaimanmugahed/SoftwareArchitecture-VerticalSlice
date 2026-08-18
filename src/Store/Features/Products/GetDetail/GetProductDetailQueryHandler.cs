
using Dapper;
using LiteBus.Queries.Abstractions;
using Store.Common.Persistence;


namespace Store.Features.Products.GetDetail
{
    public class GetProductDetailQueryHandler(
        IDbConnectionFactory connectionFactory
    ) : IQueryHandler<GetProductDetailQuery, ProductDetailDto>
    {
        public async Task<ProductDetailDto> HandleAsync(GetProductDetailQuery message, CancellationToken cancellationToken = default)
        {
            const string sql = @"
            SELECT 
                p.""Id"" as Id,
                p.""Name"" as Name,
                p.""Price"" as Price,
                p.""Quantity"" as Quantity,
                c.""Name"" as CategoryName
            FROM ""Products"" p
            INNER JOIN ""Categories"" c ON p.""CategoryId"" = c.""Id""
            WHERE p.""Id"" = @Id";

            var connection = connectionFactory.CreateConnection();


            try
            {
                var productDetail = await connection.QueryFirstOrDefaultAsync<ProductDetailDto>(
                    sql,
                    new { message.Id }
                );

                if (productDetail is null)
                {
                    throw new KeyNotFoundException($"no product exist with this is: {message.Id}");
                }

                return productDetail;
            }
            catch (Exception _)
            {
                throw;
            }
        }
    }
}