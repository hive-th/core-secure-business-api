using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ResourceAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate;

public class BankAccountRequest : BankAccount
{
    public DocumentDetailRequest Document { get; set; }
}

public class BankAccountData : BankAccount
{
    public DocumentDetail Document { get; set; }
}

public class BankAccountResponse : BankAccount
{
    public ResourcesBankResponse Bank { get; set; }
    public DocumentDetail Document { get; set; }
}