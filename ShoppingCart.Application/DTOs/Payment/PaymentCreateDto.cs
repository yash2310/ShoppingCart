using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs.Payment
{
    public class PaymentCreateDto
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
    }
}
