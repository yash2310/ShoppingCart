namespace ShoppingCart.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
