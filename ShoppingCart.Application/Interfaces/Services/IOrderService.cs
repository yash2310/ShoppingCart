using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Domain.Enums;

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
