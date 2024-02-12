using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetAllTypesQuery() : IQuery<IList<TypeResponse>>;

public sealed record TypeResponse(string Id, string Name);