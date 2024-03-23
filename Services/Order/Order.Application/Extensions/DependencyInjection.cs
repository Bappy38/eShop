using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Behaviors;
using Order.Application.EventConsumers;

namespace Order.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;

        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

        services.AddScoped<CheckedOutOrderConsumer>();

        //RabbitMQ Section.
        var eventBusUrl = configuration["EventBusSettings:HostAddress"];
        services.AddMassTransit(config =>
        {
            //Mark this as Consumer
            config.AddConsumer<CheckedOutOrderConsumer>();
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(eventBusUrl);
                //provide the queue name with consumer settings. Refactor later with Message Bus Wrapper
                cfg.ReceiveEndpoint("checkout-queue", configureEndpoint =>
                {
                    configureEndpoint.ConfigureConsumer<CheckedOutOrderConsumer>(context);
                });
            });
        });

        return services;
    }
}
