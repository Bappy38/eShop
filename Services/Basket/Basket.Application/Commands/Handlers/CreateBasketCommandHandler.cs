using Basket.Application.Abstractions.Messaging;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using Basket.Domain.Repositories;

namespace Basket.Application.Commands.Handlers;

public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, ShoppingCartResponse>
{
    private readonly IBasketRepository basketRepository;

    public CreateBasketCommandHandler(IBasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }
    public async Task<ShoppingCartResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        //TODO:: Call Discount Service and Apply Coupons
        var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items
        });
        return BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
    }
}
