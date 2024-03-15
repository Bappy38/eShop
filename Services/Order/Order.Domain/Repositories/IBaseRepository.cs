using Order.Domain.Entities;
using System.Linq.Expressions;

namespace Order.Domain.Repositories;

public interface IBaseRepository<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetItemsAsync();
    Task<IReadOnlyList<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetItemByIdAsync(int id);
    Task<T> AddItemAsync(T item);
    Task<T> UpdateItemAsync(T item);
    Task DeleteItemAsync(int id);
}
