using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetProductsByBrandQuery(string brandName) : IQuery<IList<ProductResponse>>;