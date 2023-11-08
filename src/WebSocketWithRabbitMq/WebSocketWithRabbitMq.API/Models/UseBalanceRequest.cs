namespace WebSocketWithRabbitMq.API.Models;

public class UseBalanceRequest
{
    public long IndustryId { get; set; }
    public long ChainId { get; set; }
    public long PeriodId { get; set; }
    public IEnumerable<OrderRequest> Order { get; set; } = null!;
}
