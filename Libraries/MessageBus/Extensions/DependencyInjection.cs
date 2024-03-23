using MassTransit;
using MessageBus.Event_Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBus.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, string host, string username, string password)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(host), h =>
                {
                    h.Username(username);
                    h.Password(password);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        services.AddTransient<IEventBus, EventBus>();

        return services;
    }
}
