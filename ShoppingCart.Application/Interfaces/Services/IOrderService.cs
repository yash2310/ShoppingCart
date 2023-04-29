using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IOrderService
    {
        OrderReadDto CreateOrder(OrderCreateDto createDto);
        IEnumerable<OrderReadDto> GetOrders();
        OrderReadDto GetOrder(int orderId);
        OrderReadDto UpdateOrder(int orderId, OrderStatus orderStatus);
    }
}
