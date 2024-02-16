using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsQuery() : IQuery<IList<ProductResponse>>;