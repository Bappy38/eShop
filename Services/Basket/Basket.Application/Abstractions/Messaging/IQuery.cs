using MediatR;

namespace Basket.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
