namespace Order.Domain.Entities;

public abstract class EntityBase
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
}
