using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities;

public class ProductType : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}
