namespace Basket.API.Basket.GetBasket
{

    /// <summary>
    /// 
    /// pengembalian GetBasketResponse penamaan cart harus sama dengan ketika di lakukan post karena balikannya juuga cart
    ///"cart": {
    ///    "userName": "swn",
    ///    "items": [
    ///        {
    ///            "quantity": 2,
    ///            "color": "Red",
    ///            "price": 12000,
    ///            "productId": "fe1f5da9-112d-49d3-ba8d-293c8364abab",
    ///            "productName": "IPhone X"
    ///        }
    ///   ]
    ///  }
    /// </summary>
    /// <param name="cart"></param>
    public record GetBasketResponse(ShoppingCart cart);

    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapGet("/basket/{UserName}", async (string userName, ISender sender) =>
           {
               var result = await sender.Send(new GetBasketQuery(userName));
               var response = result.Adapt<GetBasketResponse>();

               return Results.Ok(response);
           })
            .WithName("GetBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
        }
    }
}
