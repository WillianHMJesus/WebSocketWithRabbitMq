using MassTransit;

namespace WebSocketWithRabbitMq.API.MessageBrokers;

public class RabbitMqService : IMessageBrokerService
{
    private readonly IBus _bus;

    public RabbitMqService(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendMessage<T>(T message, CancellationToken cancellationToken) where T : class
    {
        await _bus.Publish(message, cancellationToken);
    }
}
