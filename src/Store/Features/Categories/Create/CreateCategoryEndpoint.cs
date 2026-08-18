

using Carter;
using LiteBus.Commands.Abstractions;

namespace Store.Features.Categories.Create
{
    public class CreateCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/categories", async (CreateCategoryInput input, ICommandMediator mediator) =>
            {
                return Results.Ok(await mediator.SendAsync(new CreateCategoryCommand(input)));
            }).WithTags("Categories");
        }
    }
}