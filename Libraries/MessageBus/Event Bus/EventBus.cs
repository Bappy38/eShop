using MassTransit;
using MessageBus.Events;

namespace MessageBus.Event_Bus;

public sealed class EventBus : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        this._publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : BaseEvent
    {
        await _publishEndpoint.Publish(message, cancellationToken);
    }
}
