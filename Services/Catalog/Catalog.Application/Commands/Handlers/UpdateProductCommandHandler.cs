using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.Handlers;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Summary = request.Summary,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Brand = request.Brand,
            Type = request.Type,
            Price = request.Price
        };
        return await productRepository.UpdateProduct(product);
    }
}
