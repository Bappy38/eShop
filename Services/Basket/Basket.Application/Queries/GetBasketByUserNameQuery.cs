using Basket.Application.Abstractions.Messaging;
using Basket.Application.Responses;

namespace Basket.Application.Queries;

public sealed record GetBasketByUserNameQuery(string UserName) : IQuery<ShoppingCartResponse>;
