using Microsoft.AspNetCore.SignalR;
using WebSocketWithRabbitMq.API.Models;

namespace WebSocketWithRabbitMq.API.Hubs;

public class UseBalanceHub : Hub
{
    public async Task SendMessage(UseBalanceRequest useBalanceRequest, CancellationToken cancellationToken)
    {
        await Clients.All.SendAsync("UseBalance", useBalanceRequest, cancellationToken);
    }
}
