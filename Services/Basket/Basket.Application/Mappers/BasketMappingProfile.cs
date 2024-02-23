using AutoMapper;
using Basket.Application.Responses;
using Basket.Domain.Entities;

namespace Basket.Application.Mappers;

public class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
        CreateMap<CartItem, CartItemResponse>().ReverseMap();
    }
}
