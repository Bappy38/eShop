using AutoMapper;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using MessageBus.Events;

namespace Basket.Application.Mappers;

public class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
        CreateMap<CartItem, CartItemResponse>().ReverseMap();
        CreateMap<Checkout, CheckedOutEvent>().ReverseMap();
    }
}
