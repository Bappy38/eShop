using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.Handlers;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Summary = request.Summary,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Brand = request.Brand,
            Type = request.Type,
            Price = request.Price
        };

        return await productRepository.CreateProduct(product);
    }
}
