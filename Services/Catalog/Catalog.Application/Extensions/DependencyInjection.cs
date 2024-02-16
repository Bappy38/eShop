using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;

        services.AddAutoMapper(applicationAssembly);

        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));

        return services;
    }
}
