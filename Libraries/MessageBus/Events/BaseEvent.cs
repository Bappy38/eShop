namespace MessageBus.Events;

public class BaseEvent
{
    public Guid Id { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    public BaseEvent()
    {
        Id = Guid.NewGuid();
        CreatedAtUtc = DateTime.UtcNow;
    }

    public BaseEvent(Guid id, DateTime createdAtUtc)
    {
        Id = id;
        CreatedAtUtc = createdAtUtc;
    }
}
