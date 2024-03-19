using Microsoft.OpenApi.Models;
using Order.Infrastructure.Data;

namespace Order.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiVersioning();

        services.AddHealthChecks()
            .Services.AddDbContext<OrderContext>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Order.API",
                Version = "v1",
            });
        });

        return services;
    }
}
