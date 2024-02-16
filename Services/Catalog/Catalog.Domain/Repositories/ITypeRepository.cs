using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories;

public interface ITypeRepository
{
    Task<IEnumerable<ProductType>> GetAllTypes();
}
