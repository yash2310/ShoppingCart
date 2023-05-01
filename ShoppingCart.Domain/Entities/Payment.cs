using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
    }
}
