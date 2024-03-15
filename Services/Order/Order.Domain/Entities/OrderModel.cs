namespace Order.Domain.Entities;

public class OrderModel : EntityBase
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public decimal TotalPrice { get; set; }
    public CardDetail? CardDetail { get; set; }
    public int PaymentMethod { get; set; }
}
