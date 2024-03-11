using RabbitMQ.Client;

namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;

public interface IRabbitMQContext
{
    IConnection GetConnection();
}