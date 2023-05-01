namespace ShoppingCart.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed
    }

    public enum OrderStatus
    {
        Pending,
        InTransit,
        OutForDelivery,
        Delivered,
        Canceled,
        Failed
    }

    public enum UserStatus
    {
        New,
        Active,
        Blocked
    }
}
