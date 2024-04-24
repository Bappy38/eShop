using Catalog.Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

namespace Catalog.API.Extensions;

public static class DependencyInjection
{
    private static string DbConnectionStringKey = "DatabaseSettings:ConnectionString";
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        //services.AddControllers();
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

        services.AddIdentity();

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        var userPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();

        services.AddControllers(config =>
        {
            config.Filters.Add(new AuthorizeFilter(userPolicy));
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:9009";
                options.Audience = "Catalog";
            });

        services.AddAuthorization(options =>
        {
            options
            .AddPolicy(
                Policy.HasReadPermission, 
                policy => policy.RequireClaim(ClaimType.Scope, Scope.Read));
        });

        return services;
    }
}
