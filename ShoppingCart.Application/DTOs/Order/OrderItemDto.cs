using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DTOs.Order
{
    public class OrderItemDto
    {
        public OrderCreateDto OrderDetail { get; set; } = new OrderCreateDto();
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
