using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderDetail OrderDetail { get; set; } = new OrderDetail();
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
