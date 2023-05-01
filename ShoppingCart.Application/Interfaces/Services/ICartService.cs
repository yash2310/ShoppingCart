using ShoppingCart.Application.DTOs.Cart;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface ICartService
    {
        CartDto AddToCart(CartDto cart);
        IEnumerable<CartDto> CartItems(int userId);
        bool DeleteFromCart(int userId, int productId);
    }
}
