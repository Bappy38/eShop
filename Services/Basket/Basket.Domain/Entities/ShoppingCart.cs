namespace Basket.Domain.Entities;

public class ShoppingCart
{
    public string UserName { get; set; }
    public List<CartItem> Items { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }
    }
}
