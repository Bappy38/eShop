using Catalog.Domain.Entities;
using MongoDB.Driver;
using System.Reflection;
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
        //TODO:: Unable following line in prod mode
        //var templatePath = Path.Combine("Data", "SeedData", $"{modelName.ToLower()}s.json");

        var templatePath = Path.Combine(
            Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location
                ),
            "Data",
            "SeedData",
            $"{modelName.ToLower()}s.json"
        );

        if (!File.Exists(templatePath))
        {
            return;
        }

        Console.WriteLine($"Seeding Data for Model {modelName} from Template {templatePath}");

        var data = File.ReadAllText(templatePath);
        var entities = JsonSerializer.Deserialize<List<T>>(data);

        if (entities is null || !entities.Any())
        {
            return;
        }

        collection.InsertMany(entities);
    }
}
