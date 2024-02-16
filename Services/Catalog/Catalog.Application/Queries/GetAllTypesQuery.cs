using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetAllTypesQuery() : IQuery<IList<TypeResponse>>;