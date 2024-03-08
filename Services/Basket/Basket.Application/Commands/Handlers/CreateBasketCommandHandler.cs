using Basket.Application.Abstractions.Messaging;
using Basket.Application.GrpcServices;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using Basket.Domain.Repositories;

namespace Basket.Application.Commands.Handlers;

public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, ShoppingCartResponse>
{
    private readonly IBasketRepository basketRepository;
    private readonly DiscountGrpcService discountGrpcService;

    public CreateBasketCommandHandler(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
    {
        this.basketRepository = basketRepository;
        this.discountGrpcService = discountGrpcService;
    }
    public async Task<ShoppingCartResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        foreach(var item in request.Items)
        {
            var coupon = await discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }

        var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
        });
        return BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
    }
}
