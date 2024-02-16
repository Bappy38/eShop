using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.Handlers;

public class GetProductByNameQueryHandler : IQueryHandler<GetProductByNameQuery, IList<ProductResponse>>
{
    private readonly IProductRepository productRepository;

    public GetProductByNameQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductByName(request.productName);
        var productResponses = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);
        return productResponses;
    }
}
