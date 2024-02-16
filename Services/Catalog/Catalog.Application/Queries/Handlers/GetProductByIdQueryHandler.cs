using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductById(request.productId);
        var productResponse = ProductMapper.Mapper.Map<ProductResponse>(product);
        return productResponse;
    }
}
