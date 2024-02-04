using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(Guid productId);
    Task<IEnumerable<Product>> GetProductByName(string productName);
    Task<IEnumerable<Product>> GetProductByBrand(string brandName);
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string productId);
}
