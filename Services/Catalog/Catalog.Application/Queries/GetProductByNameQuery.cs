using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetProductByNameQuery(string productName) : IQuery<IList<ProductResponse>>;
