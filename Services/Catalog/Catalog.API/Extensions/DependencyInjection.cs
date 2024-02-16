using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions;

public static class DependencyInjection
{
    private static string DbConnectionStringKey = "DatabaseSettings:ConnectionString";
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddApiVersioning();

        services.AddHealthChecks()
            .AddMongoDb(
                config?[DbConnectionStringKey],
                "Catalog MongoDB Health Check",
                HealthStatus.Degraded);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Catalog.API",
                    Version = "v1"
                });
        });

        return services;
    }
}
