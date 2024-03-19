using Microsoft.Extensions.Logging;
using Order.Domain.Entities;

namespace Order.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (orderContext.Orders.Any())
        {
            return;
        }

        orderContext.Orders.AddRange(GetOrders());
       await orderContext.SaveChangesAsync();
        logger.LogInformation($"Seed data added successfully in OrderDb");
    }

    private static List<OrderModel> GetOrders()
    {
        var orders = new List<OrderModel>
        {
            new OrderModel
            {
                UserName = "Bappy",
                FirstName = "Iqbal",
                LastName = "Bappy",
                EmailAddress = "iqbal.bappy.16@gmail.com",
                AddressLine = "Mirpur 13",
                Country = "Bangladesh",
                City = "Dhaka",
                ZipCode = "1207",
                TotalPrice = 5000,
                CardName = "Iqbal Bappy",
                CardNumber = "1234567890123456",
                Expiration = "12/25",
                CVV = "123",
                PaymentMethod = 1
            }
        };
        return orders;
    }
}
