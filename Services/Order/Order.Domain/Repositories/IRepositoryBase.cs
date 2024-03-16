using Order.Domain.Entities;
using System.Linq.Expressions;

namespace Order.Domain.Repositories;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetItemsAsync();
    Task<IReadOnlyList<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetItemByIdAsync(int id);
    Task<T> AddItemAsync(T item);
    Task UpdateItemAsync(T item);
    Task DeleteItemAsync(T item);
}
