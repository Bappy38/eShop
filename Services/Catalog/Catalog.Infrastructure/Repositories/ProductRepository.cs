using Catalog.Domain.Entities;
using Catalog.Domain.QuerySpecs;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
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

    public async Task<PagedResponse<Product>> GetProducts(ProductQueryParams queryParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(queryParams.Search))
        {
            var searchFilter = builder.Regex(p => p.Name, new BsonRegularExpression(queryParams.Search));
            filter &= searchFilter;
        }

        if (!string.IsNullOrWhiteSpace(queryParams.BrandId))
        {
            var brandFilter = builder.Eq(p => p.Brand.Id, queryParams.BrandId);
            filter &= brandFilter;
        }

        if (!string.IsNullOrWhiteSpace(queryParams.TypeId))
        {
            var typeFilter = builder.Eq(p => p.Type.Id, queryParams.TypeId);
            filter &= typeFilter;
        }

        var sortDefinition = queryParams.IsAscending
            ? Builders<Product>.Sort.Ascending(p => p.Name)
            : Builders<Product>.Sort.Descending(p => p.Name);

        if (!string.IsNullOrWhiteSpace(queryParams.SortKey))
        {
            sortDefinition = queryParams.IsAscending
                ? Builders<Product>.Sort.Ascending(queryParams.SortKey)
                : Builders<Product>.Sort.Descending(queryParams.SortKey);
        }

        return new PagedResponse<Product>
        {
            PageIndex = queryParams.PageIndex,
            PageSize = queryParams.PageSize,
            Count = await _context.Products.CountDocumentsAsync(filter),
            Data = await _context
                        .Products
                        .Find(filter)
                        .Sort(sortDefinition)
                        .Skip(queryParams.Skip())
                        .Limit(queryParams.PageSize)
                        .ToListAsync()
        };
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
