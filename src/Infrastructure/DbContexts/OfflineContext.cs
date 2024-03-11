using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;

namespace Core.Secure.Business.Infrastructure.DbContexts;

public class OfflineContext : IOfflineContext
{
    public HashSet<OfflineQueueDetail> OfflineQueues { get; set; }

    public OfflineContext()
    {
        OfflineQueues = new HashSet<OfflineQueueDetail>();
    }

    public void AddOfflineQueues(OfflineQueueDetail offlineQueueDetail)
    {
        OfflineQueues.Add(offlineQueueDetail);
    }

    public void RemoveOfflineQueues(Guid id)
    {
        OfflineQueues.RemoveWhere(m => m.Id == id);
    }

    public void AddTryTimes(OfflineQueueDetail offlineQueueDetail)
    {
        OfflineQueues.RemoveWhere(m => m.Id == offlineQueueDetail.Id);
        OfflineQueues.Add(offlineQueueDetail);
    }
}