using AutoMapper;
using MassTransit;
using MediatR;
using MessageBus.Events;
using Microsoft.Extensions.Logging;
using Order.Application.Commands;

namespace Order.Application.EventConsumers;

public class CheckedOutOrderConsumer : IConsumer<CheckedOutEvent>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckedOutOrderConsumer> _logger;

    public CheckedOutOrderConsumer(IMediator mediator, IMapper mapper, ILogger<CheckedOutOrderConsumer> logger)
    {
        this._mediator = mediator;
        this._mapper = mapper;
        this._logger = logger;
    }

    public async Task Consume(ConsumeContext<CheckedOutEvent> context)
    {
        try
        {
            var checkoutOrderCommand = _mapper.Map<CheckoutOrderCommand>(context.Message);
            await _mediator.Send(checkoutOrderCommand);
            _logger.LogInformation($"CheckedOutEvent Consumed Successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error Occurred while Consuming CheckedOutEvent");
            _logger.LogError(ex.ToString());
            throw;
        }
    }
}
