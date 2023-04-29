using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DTOs.Order
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }

        //public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
