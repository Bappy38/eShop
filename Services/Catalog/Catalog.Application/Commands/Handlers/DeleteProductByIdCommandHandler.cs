using Catalog.Application.Abstractions.Messaging;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Commands.Handlers;

public class DeleteProductByIdCommandHandler : ICommandHandler<DeleteProductByIdCommand, bool>
{
    private readonly IProductRepository productRepository;

    public DeleteProductByIdCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await productRepository.DeleteProduct(request.Id);
        return result;
    }
}
