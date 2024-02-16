using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
