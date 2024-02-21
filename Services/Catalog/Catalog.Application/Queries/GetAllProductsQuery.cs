using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.QuerySpecs;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsQuery(ProductQueryParams queryParams) : IQuery<PagedResponse<ProductResponse>>;