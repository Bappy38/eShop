using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    private readonly IProductRepository productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(
        GetAllProductsQuery request, 
        CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProducts();
        var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        return productsResponse;
    }
}
