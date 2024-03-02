using Discount.Application.Abstractions.Messaging;
using Discount.Domain.Repositories;
using Grpc.Core;

namespace Discount.Application.Commands.Handlers;

public class DeleteDiscountCommandHandler : ICommandHandler<DeleteDiscountCommand, bool>
{
    private readonly IDiscountRepository discountRepository;

    public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        this.discountRepository = discountRepository;
    }
    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await discountRepository.DeleteDiscount(request.productName);

        if (!isDeleted)
        {
            throw new RpcException(new Status(StatusCode.Internal, $"Failed to delete discount with product name {request.productName}"));
        }
        return isDeleted;
    }
}
