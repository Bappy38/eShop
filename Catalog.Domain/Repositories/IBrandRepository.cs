using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrands();
}
