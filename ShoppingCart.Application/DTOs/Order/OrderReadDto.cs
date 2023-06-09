﻿using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs.Order
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        //public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
