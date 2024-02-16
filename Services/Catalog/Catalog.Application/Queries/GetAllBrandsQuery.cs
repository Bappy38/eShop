using Catalog.Application.Abstractions.Messaging;

namespace Catalog.Application.Queries;

public sealed record GetAllBrandsQuery() : IQuery<IList<BrandReponse>>;
