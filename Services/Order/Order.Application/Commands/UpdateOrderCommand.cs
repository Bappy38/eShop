using Order.Application.Abstractions.Messaging;
using Order.Domain.Entities;

namespace Order.Application.Commands;

public sealed record UpdateOrderCommand(
    int Id,
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
    int PaymentMethod) : ICommand;
