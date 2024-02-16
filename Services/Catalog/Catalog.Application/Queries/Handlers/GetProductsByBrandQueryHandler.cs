using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponse>>
{
    private readonly IProductRepository productRepository;

    public GetProductsByBrandQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductByBrand(request.brandName);
        var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        return productsResponse;
    }
}
