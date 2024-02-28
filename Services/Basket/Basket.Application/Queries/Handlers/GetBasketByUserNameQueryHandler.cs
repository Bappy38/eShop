using Basket.Application.Abstractions.Messaging;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Domain.Repositories;

namespace Basket.Application.Queries.Handlers;

public sealed class GetBasketByUserNameQueryHandler : IQueryHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
{
    private readonly IBasketRepository basketRepository;

    public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }
    public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await basketRepository.GetBasket(request.UserName);
        var shoppingCartResponse = BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
        return shoppingCartResponse;
    }
}
