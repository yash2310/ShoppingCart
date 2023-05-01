using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs
{
    public class BaseMessageBusDto
    {
        public EventType Event { get; set; }
    }
}
