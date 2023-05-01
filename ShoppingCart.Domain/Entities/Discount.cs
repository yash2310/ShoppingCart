namespace ShoppingCart.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal DiscountPercent { get; set; }
    }
}
