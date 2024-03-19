namespace Order.Application.Responses;

public sealed record OrderResponse(
    string Id,
    string UserName,
    double TotalPrice,
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string City,
    string ZipCode
    );
