namespace ShoppingCart.Application.DTOs.Order
{
    public class OrderItemDto
    {
        public OrderCreateDto OrderDetail { get; set; } = new OrderCreateDto();
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
