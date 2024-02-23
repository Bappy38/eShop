using Basket.Application.Abstractions.Messaging;
using Basket.Application.Responses;
using Basket.Domain.Entities;

namespace Basket.Application.Commands;

public sealed record CreateBasketCommand(string UserName, List<CartItem> Items) : ICommand<ShoppingCartResponse>;
