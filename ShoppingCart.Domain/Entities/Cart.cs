namespace ShoppingCart.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
