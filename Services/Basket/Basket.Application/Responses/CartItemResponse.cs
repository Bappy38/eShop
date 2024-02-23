namespace Basket.Application.Responses;

public sealed record CartItemResponse(
    string ProductId, 
    string ProductName, 
    string ImageFile, 
    int Quantity, 
    decimal Price);
