namespace ShoppingCart.Application.DTOs.Product
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DiscountId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
