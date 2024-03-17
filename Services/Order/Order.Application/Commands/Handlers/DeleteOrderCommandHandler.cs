using Microsoft.Extensions.Logging;
using Order.Application.Abstractions.Messaging;
using Order.Application.Exceptions;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Application.Commands.Handlers;

public sealed class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand>
{
    private readonly ILogger<DeleteOrderCommandHandler> _logger;
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(
        ILogger<DeleteOrderCommandHandler> logger,
        IOrderRepository orderRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetItemByIdAsync(request.Id);
        if (orderToDelete is null)
        {
            throw new OrderNotFoundException(nameof(OrderModel), request.Id);
        }

        await _orderRepository.DeleteItemAsync(orderToDelete);
        _logger.LogInformation($"Order with id {orderToDelete.Id} is deleted successfully");
    }
}
