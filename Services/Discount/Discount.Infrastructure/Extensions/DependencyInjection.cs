using Discount.Domain.Repositories;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Discount.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetValue<string>("DatabaseSettings:ConnectionString");

        services.AddHealthChecks().AddNpgSql(connectionString, "SELECT 1", null, "Postgre DB", HealthStatus.Unhealthy);

        services.AddScoped<IDiscountRepository, DiscountRepository>();

        return services;
    }
}
