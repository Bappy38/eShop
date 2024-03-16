using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Repositories;
using Order.Infrastructure.Data;
using System.Linq.Expressions;

namespace Order.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
    protected readonly OrderContext _dbContext;

    public RepositoryBase(OrderContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<T> AddItemAsync(T item)
    {
        await _dbContext.Set<T>().AddAsync(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task DeleteItemAsync(T item)
    {
        _dbContext.Set<T>().Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetItemByIdAsync(int id)
    {
        var item = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        return item;
    }

    public async Task<IReadOnlyList<T>> GetItemsAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task UpdateItemAsync(T item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
