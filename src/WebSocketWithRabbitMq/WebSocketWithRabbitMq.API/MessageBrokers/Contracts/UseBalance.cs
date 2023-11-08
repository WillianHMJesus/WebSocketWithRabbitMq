using WebSocketWithRabbitMq.API.Models;

namespace WebSocketWithRabbitMq.API.MessageBrokers.Contracts;

public class UseBalance
{
    public UseBalance(UseBalanceRequest request)
    {
        Id = Guid.NewGuid();
        Request = request;
    }

    public Guid Id { get; init; }
    public UseBalanceRequest Request { get; init; }
}
