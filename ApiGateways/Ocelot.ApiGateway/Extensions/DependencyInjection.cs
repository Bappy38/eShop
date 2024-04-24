using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.ApiGateway.Constants;

namespace Ocelot.ApiGateway.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        var authScheme = AuthScheme.EShoppingGatewayAuthScheme;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(authScheme, options =>
            {
                options.Authority = "https://localhost:9009";
                options.Audience = "EShoppingGateway";
            });

        return services;
    }
}
