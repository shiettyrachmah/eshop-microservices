
using Catalog.API.Products.CreateProduct;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.DeleteProductById
{
    public record DeleteProductRes(bool isSuccess);

    public class DeleteProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/deleteProduct/{id}", async(Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                var resp = new DeleteProductRes(result.isSuccess);
                return Results.Ok(resp);
            })
             .WithName("DeleteProductById")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product By Id")
            .WithDescription("Delete Product By Id");

        }
    }
}
