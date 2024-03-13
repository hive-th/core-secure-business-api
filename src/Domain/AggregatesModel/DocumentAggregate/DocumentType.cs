namespace Core.Secure.Business.Domain.AggregatesModel.DocumentAggregate;

public enum DocumentNoType
{
    ORDER_REQUEST_NUMBER,
    ORDER_NUMBER,
    ORDER_CHARGE_NUMBER
}

public enum DocumentType
{
    ORDER_REQUEST,
    PURCHASE_ORDER,
    BILLING_NOTE,
    RECEIPT,
    DELIVERY_NOTE,
    GOODS_RECEIPT,
    CREDIT_NOTE
}

public enum GoodsReceiptStatus
{
    DRAFT,
    CONFIRMED,
    APPROVED,
    REJECTED,
}