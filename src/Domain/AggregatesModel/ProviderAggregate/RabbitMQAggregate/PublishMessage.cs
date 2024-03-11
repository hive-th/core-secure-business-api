namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;

public class PublishMessage<T>
{
    public string EventType { get; set; }
    public T Payload { get; set; }
}