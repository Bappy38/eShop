using AutoMapper;
using Order.Application.Commands;
using Order.Application.Responses;
using Order.Domain.Entities;

namespace Order.Application.Mappers;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderModel, OrderResponse>().ReverseMap();
        CreateMap<OrderModel, CheckoutOrderCommand>().ReverseMap();
        CreateMap<OrderModel, UpdateOrderCommand>().ReverseMap();
    }
}
