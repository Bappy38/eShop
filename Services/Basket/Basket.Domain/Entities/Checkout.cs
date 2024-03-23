namespace Basket.Domain.Entities;

public class Checkout
{
    //TODO:: Need to refactor this model and all other model related to it according to business logic. Here, some unnecessary property have added to simplify things for now.
    public string UserName { get; set; }
    public double TotalPrice { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }

    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}
