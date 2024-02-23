namespace Basket.Application.Responses;

public sealed class ShoppingCartResponse
{
    public string UserName { get; init; }
    public List<CartItemResponse> Items { get; init; }
    public decimal TotalPrice
    {
        get
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }
    }
}
