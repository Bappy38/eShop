using Order.Domain.Entities;

namespace Order.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<OrderModel>
{
    Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
