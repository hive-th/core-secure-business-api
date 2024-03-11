namespace Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;

public enum PublishMessageTypeEnum
{
    PRE_DELETE_ACCOUNTS,
    CONFIRM_DELETE_ACCOUNTS,
    CANCEL_DELETE_ACCOUNTS
}