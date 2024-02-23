using Basket.Application.Abstractions.Messaging;

namespace Basket.Application.Commands;

public sealed record DeleteBasketByUserNameCommand(string UserName) : ICommand<bool>;