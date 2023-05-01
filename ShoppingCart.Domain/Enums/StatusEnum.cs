using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
