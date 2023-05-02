using ShoppingCart.Application.DTOs.Cart;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface ICartService
    {
        IEnumerable<CartDto> CartItems(int userId);
        CartDto AddToCart(int userId, CartDto cart);
        CartDto UpdateCart(int userId, CartDto cart);
        bool DeleteFromCart(int userId, int productId);
    }
}
