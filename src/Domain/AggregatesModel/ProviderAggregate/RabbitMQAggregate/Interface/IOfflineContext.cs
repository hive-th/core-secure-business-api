namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;

public interface IOfflineContext
{
    HashSet<OfflineQueueDetail> OfflineQueues { get; set; }
    void AddOfflineQueues(OfflineQueueDetail offlineQueueDetail);
    void RemoveOfflineQueues(Guid id);
    public void AddTryTimes(OfflineQueueDetail offlineQueueDetail);
}