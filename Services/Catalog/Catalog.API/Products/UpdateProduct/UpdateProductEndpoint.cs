
using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string ImageFile, string Description, decimal Price);

    public record UpdateProductResponse(Product Product);
    public class UpdateProductCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/product", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var req = await sender.Send(new GetProductByIdQuery(request.Id));
                var res = req.Adapt<UpdateProductResponse>();
                return Results.Ok(res);
            })
            .WithName("UpdateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
