using MessageBus.Events;

namespace MessageBus.Event_Bus;

public interface IEventBus
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : BaseEvent;
}
