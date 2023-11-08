using MassTransit;
using WebSocketWithRabbitMq.API.MessageBrokers;
using WebSocketWithRabbitMq.API.MessageBrokers.Consumers;

namespace WebSocketWithRabbitMq.API.Common;

public static class Extensions
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UseBalanceConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IMessageBrokerService, RabbitMqService>();

        return services;
    }
}
