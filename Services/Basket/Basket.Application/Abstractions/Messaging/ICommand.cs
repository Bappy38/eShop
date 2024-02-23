using MediatR;

namespace Basket.Application.Abstractions.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}