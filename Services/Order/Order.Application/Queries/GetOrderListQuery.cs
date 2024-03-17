using Order.Application.Abstractions.Messaging;
using Order.Application.Responses;

namespace Order.Application.Queries;

public sealed record GetOrderListQuery(string UserName) : IQuery<List<OrderResponse>>;
