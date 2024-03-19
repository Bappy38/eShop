using Microsoft.EntityFrameworkCore;

namespace Order.API.Extensions;

public static class DbExtension
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation($"DB Migration Started: {nameof(TContext)}");
                SeedData(seeder, context, services);
                logger.LogInformation($"DB Migration Completed: {nameof(TContext)}");
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred while migrating db: {nameof(TContext)}", ex);
            }
        }
        return host;
    }

    private static void SeedData<TContext>(Action<TContext, IServiceProvider> seeder, TContext? context, IServiceProvider services) where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }
}
