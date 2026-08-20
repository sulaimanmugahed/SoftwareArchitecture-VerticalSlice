
using Carter;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Persistence;

namespace Store.Features.Categories
{
    public record CategoryDetailDto(int Id, string Name, int ProductsCount);

    public class GetCategoryDetailEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/categories/{id}/detail", async (int id, AppDbContext dbContext) =>
            {
                //
                var category = await dbContext.Categories.FindAsync(id);
                if (category is null)
                {
                    return Results.BadRequest("not found");
                }

                var productsCount = await dbContext.Products.CountAsync(p => p.CategoryId == id);


                return Results.Ok(new CategoryDetailDto(category.Id, category.Name, productsCount));

                //
            }).WithTags("Categories");
        }
    }

}