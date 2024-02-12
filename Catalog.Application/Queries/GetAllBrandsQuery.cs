using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetAllBrandsQuery() : IQuery<IList<BrandReponse>>;

public sealed record BrandReponse(
    string Id, 
    string Name);
