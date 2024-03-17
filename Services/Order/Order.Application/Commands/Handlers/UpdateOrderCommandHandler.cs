using AutoMapper;
using Microsoft.Extensions.Logging;
using Order.Application.Abstractions.Messaging;
using Order.Application.Exceptions;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Application.Commands.Handlers;

public sealed class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<UpdateOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(
        IMapper mapper,
        IOrderRepository orderRepository,
        ILogger<UpdateOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToUpdate = await _orderRepository.GetItemByIdAsync(request.Id);

        if (orderToUpdate is null)
        {
            throw new OrderNotFoundException(nameof(OrderModel), request.Id);
        }

        _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(OrderModel));

        await _orderRepository.UpdateItemAsync(orderToUpdate);
        _logger.LogInformation($"Order with id {orderToUpdate.Id} updated successfully");
    }
}
