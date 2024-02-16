using Catalog.Application.Abstractions.Messaging;
using Catalog.Application.Mappers;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.Handlers;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = ProductMapper.Mapper.Map<Product>(request);

        if (product is null)
        {
            throw new Exception("There is an issue with mapping while creating new product.");
        }

        var newProduct = await productRepository.CreateProduct(product);
        return ProductMapper.Mapper.Map<ProductResponse>(newProduct);
    }
}
