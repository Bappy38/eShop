using Catalog.Domain.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public class ContextSeed
{
    public static void SeedData<T>(IMongoCollection<T> collection) where T : BaseEntity
    {
        if (collection.Find(entity => true).Any())
        {
            return;
        }

        var modelName = typeof(T).Name;
        var templatePath = Path.Combine("Data", "SeedData", $"{modelName}s.json");

        if (!File.Exists(templatePath))
        {
            return;
        }

        var data = File.ReadAllText(templatePath);
        var entities = JsonSerializer.Deserialize<List<T>>(data);

        if (entities is null || !entities.Any())
        {
            return;
        }

        collection.InsertMany(entities);
    }
}
