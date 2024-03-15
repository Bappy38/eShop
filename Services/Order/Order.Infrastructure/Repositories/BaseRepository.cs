using Order.Domain.Entities;
using Order.Domain.Repositories;
using System.Linq.Expressions;

namespace Order.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
{
    public Task<T> AddItemAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteItemAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetItemByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateItemAsync(T item)
    {
        throw new NotImplementedException();
    }
}
