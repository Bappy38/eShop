using AutoMapper;
using Order.Application.Abstractions.Messaging;
using Order.Application.Responses;
using Order.Domain.Repositories;

namespace Order.Application.Queries.Handlers;

public sealed class GetOrderListQueryHandler : IQueryHandler<GetOrderListQuery, List<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByUserNameAsync(request.UserName);
        var orderResponses = _mapper.Map<List<OrderResponse>>(orders);
        return orderResponses;
    }
}
