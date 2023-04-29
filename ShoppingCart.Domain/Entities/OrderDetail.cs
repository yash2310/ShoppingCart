using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }

        //public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
