using MassTransit;
using Microsoft.AspNetCore.SignalR;
using WebSocketWithRabbitMq.API.Hubs;
using WebSocketWithRabbitMq.API.MessageBrokers.Contracts;

namespace WebSocketWithRabbitMq.API.MessageBrokers.Consumers;

public class UseBalanceConsumer : IConsumer<UseBalance>
{
    private readonly IHubContext<UseBalanceHub> _hubContext;

    public UseBalanceConsumer(IHubContext<UseBalanceHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<UseBalance> context)
    {
        await Task.Delay(60000);

        await _hubContext.Clients.All.SendAsync("UseBalance", context.Message.Request);

        await Task.CompletedTask;
    }
}
