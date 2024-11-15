﻿using Discount.Grpc.Protos;

namespace Basket.API.Basket.StoreBasket
{
    /// <summary>
    /// CRUD :
    /// store (upsert-create and update) shopping cart with items thats include :
    /// add item 
    /// remove
    /// update shopping item.
    /// 
    /// GRPC Basket operation
    /// when store basket : getdiscount and deduct discount coupun from item price
    /// 
    /// Async basket operation:
    /// checkout basket and publish event to rabbitmq message broker
    /// </summary>

    public record StoreBasketCommand(ShoppingCart Cart): ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.Cart.UserName).NotNull().WithMessage("Username is required");
        }
    }
    public class StoreBasketHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.Cart, cancellationToken);

            // ShoppingCart cart = command.Cart;
            await repository.StoreBasket(command.Cart, cancellationToken);
            return new StoreBasketResult(command.Cart.UserName);
        }

        public async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            //cara menggunakan coupon di basket. coupon amount akan di apply di ssetiap item dari basket
            foreach (var item in cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);

                item.Price -= coupon.Amount;
            }
        }
    }
}
