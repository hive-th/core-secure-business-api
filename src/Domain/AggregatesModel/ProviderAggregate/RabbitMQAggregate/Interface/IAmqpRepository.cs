namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;

public interface IAmqpRepository
{
    void PublishMessage(string message);
}