using Basket.Domain.Entities;

namespace Basket.Domain.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName);
    Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
    Task<bool> DeleteBasket(string userName);
}
