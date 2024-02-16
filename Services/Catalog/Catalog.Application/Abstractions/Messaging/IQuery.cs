using MediatR;

namespace Catalog.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
