using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.QuerySpecs;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, PagedResponse<ProductResponse>>
{
    private readonly IProductRepository productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<PagedResponse<ProductResponse>> Handle(
        GetAllProductsQuery request, 
        CancellationToken cancellationToken)
    {
        var pagedResponse = await productRepository.GetProducts(request.queryParams);

        var mappedPagedResponse = ProductMapper.Mapper.Map<PagedResponse<ProductResponse>>(pagedResponse);
        return mappedPagedResponse;
    }
}
