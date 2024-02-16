using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> DeleteProduct(string productId)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
        var deleteResult = await _context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string brandName)
    {
        var filter = Builders<Product>.Filter.Eq(prop => prop.Brand.Name, brandName);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<Product> GetProductById(string productId)
    {
        return await _context.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string productName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
