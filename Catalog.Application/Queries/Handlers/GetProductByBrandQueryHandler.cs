using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetProductByBrandQueryHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
{
    private readonly IProductRepository productRepository;

    public GetProductByBrandQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductByBrand(request.BrandName);
        var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        return productsResponse;
    }
}
