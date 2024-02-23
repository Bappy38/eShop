using Basket.Application.Abstractions.Messaging;
using Basket.Domain.Repositories;

namespace Basket.Application.Commands.Handlers;

public sealed class DeleteBasketByUserNameCommandHandler : ICommandHandler<DeleteBasketByUserNameCommand, bool>
{
    private readonly IBasketRepository basketRepository;

    public DeleteBasketByUserNameCommandHandler(IBasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }
    public async Task<bool> Handle(DeleteBasketByUserNameCommand request, CancellationToken cancellationToken)
    {
        var result = await basketRepository.DeleteBasket(request.UserName);
        return result;
    }
}
