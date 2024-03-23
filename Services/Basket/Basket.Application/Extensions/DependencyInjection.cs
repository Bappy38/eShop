using Basket.Application.GrpcServices;
using Discount.Grpc.Protos;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);

        var grpcServerUrl = configuration["GrpcSettings:DiscountUrl"];
        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
            (options => options.Address = options.Address = new Uri(grpcServerUrl));

        var eventBusUrl = configuration["EventBusSettings:HostAddress"];
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(eventBusUrl);
            });
        });

        services.AddScoped<DiscountGrpcService>();

        return services;
    }
}
