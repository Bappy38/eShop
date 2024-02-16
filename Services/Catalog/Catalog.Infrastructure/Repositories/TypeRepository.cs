using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class TypeRepository : ITypeRepository
{
    private readonly ICatalogContext _context;

    public TypeRepository(ICatalogContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await _context.Types.Find(t => true).ToListAsync();
    }
}
