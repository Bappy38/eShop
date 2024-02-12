using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.Entities;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsQuery() : IQuery<IList<ProductResponse>>;

public sealed record ProductResponse(
    string Name, 
    string Summary, 
    string Description,
    string ImageFile,
    ProductBrand Brand,
    ProductType Type,
    decimal Price);