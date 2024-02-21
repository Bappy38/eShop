using Catalog.Domain.Entities;
using Catalog.Domain.QuerySpecs;

namespace Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<PagedResponse<Product>> GetProducts(ProductQueryParams queryParams);
    Task<Product> GetProductById(string productId);
    Task<IEnumerable<Product>> GetProductByName(string productName);
    Task<IEnumerable<Product>> GetProductByBrand(string brandName);
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string productId);
}
