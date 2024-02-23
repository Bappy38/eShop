using Basket.Domain.Repositories;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Basket.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        //Redis Settings
        var redisConnectionString = config.GetValue<string>("CacheSettings:ConnectionString");

        if (string.IsNullOrWhiteSpace(redisConnectionString))
        {
            Console.WriteLine($"Redis Connection String is null.");
            return services;
        }

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
        });

        services.AddHealthChecks().AddRedis(redisConnectionString, "Redis Health", HealthStatus.Degraded);

        services.AddScoped<IBasketRepository, BasketRepository>();

        return services;
    }
}
