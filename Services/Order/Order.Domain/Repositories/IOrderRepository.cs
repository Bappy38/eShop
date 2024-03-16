using Order.Domain.Entities;

namespace Order.Domain.Repositories;

public interface IOrderRepository : IRepositoryBase<OrderModel>
{
    Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName);
}
