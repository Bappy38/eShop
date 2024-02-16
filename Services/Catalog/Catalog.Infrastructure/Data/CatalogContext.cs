using Catalog.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductType> Types { get; }
    public IMongoCollection<ProductBrand> Brands { get; }

    public CatalogContext(IConfiguration config)
    {
        var connectionString = config.GetValue<string>("DatabaseSettings:ConnectionString");
        var databaseName = config.GetValue<string>("DatabaseSettings:DatabaseName");

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        Products = database.GetCollection<Product>(typeof(Product).Name);
        Types = database.GetCollection<ProductType>(typeof(ProductType).Name);
        Brands = database.GetCollection<ProductBrand>(typeof(ProductBrand).Name);

        ContextSeed.SeedData<Product>(Products);
        ContextSeed.SeedData<ProductType>(Types);
        ContextSeed.SeedData<ProductBrand>(Brands);
    }
}
