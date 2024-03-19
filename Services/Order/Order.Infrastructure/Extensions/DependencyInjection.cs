using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Repositories;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.Extensions;

public  static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(3);
                sqlServerAction.CommandTimeout(30);
                sqlServerAction.MigrationsAssembly("Order.Infrastructure");
            })
            .AddInterceptors(new GenericEntityInterceptor());
        });
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}
