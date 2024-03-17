using AutoMapper;
using Microsoft.Extensions.Logging;
using Order.Application.Abstractions.Messaging;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Application.Commands.Handlers;

public sealed class CheckoutOrderCommandHandler : ICommandHandler<CheckoutOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(
        IOrderRepository orderRepository, 
        IMapper mapper, 
        ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<OrderModel>(request);
        var generatedOrder = await _orderRepository.AddItemAsync(order);
        _logger.LogInformation($"Order with id {generatedOrder.Id} places successfully");
        return generatedOrder.Id;
    }
}
