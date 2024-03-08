using Discount.Grpc.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);

        var grpcServerUrl = config["GrpcSettings:DiscountUrl"];
        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
            (options => options.Address = options.Address = new Uri(grpcServerUrl));

        return services;
    }
}
