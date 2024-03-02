using Discount.Application.Abstractions.Messaging;

namespace Discount.Application.Commands;

public sealed record DeleteDiscountCommand(string productName) : ICommand<bool>;