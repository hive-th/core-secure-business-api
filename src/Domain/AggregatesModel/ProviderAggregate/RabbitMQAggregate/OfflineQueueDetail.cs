namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;

public class OfflineQueueDetail
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public int TryTimes { get; set; }
}