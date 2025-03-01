using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.CreationProduct
{
    public record CreateProductRequest(string Name, string Description, decimal Price);

    public record CreateProductResponse(bool res);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
               
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                return Results.Created($"/products", result);

            }).WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product"); ;

        }
    }
}
