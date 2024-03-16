using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Repositories;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<OrderModel>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByUserNameAsync(string userName)
    {
        var orderList = await _dbContext
            .Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        return orderList;
    }
}
