using MediatR;

namespace Order.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>;
