namespace Basket.Domain.Entities;

public class CartItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string ImageFile { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
