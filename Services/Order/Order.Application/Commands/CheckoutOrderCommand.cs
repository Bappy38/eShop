using Order.Application.Abstractions.Messaging;

namespace Order.Application.Commands;

public sealed record CheckoutOrderCommand(
    string UserName,
    decimal TotalPrice,
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string City,
    string ZipCode,
    string CardName,
    string CardNumber,
    string Expiration,
    string CVV,
    int PaymentMethod) : ICommand<int>;
