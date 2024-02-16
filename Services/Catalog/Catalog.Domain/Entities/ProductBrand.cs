using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities;

public class ProductBrand : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}
