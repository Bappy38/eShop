using Catalog.Domain.Entities;

public sealed record ProductResponse(
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    ProductBrand Brand,
    ProductType Type,
    decimal Price);