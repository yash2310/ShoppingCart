using AutoMapper;
using ShoppingCart.Application.DTOs.Cart;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Services
{
    public class CartService //: ICartService
    {
        private readonly ICartRepository<Cart> repository;
        private readonly IMapper mapper;

        public CartService(ICartRepository<Cart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public CartDto AddToCart(int userId, CartDto cart)
        {
            var cartData = repository.GetWithProduct(userId);
            if (cartData == null)
            {
                cartData = new Cart();
                cartData.UserId = userId;
                cartData.CartProducts.Add(mapper.Map<CartProduct>(cart));

                repository.Add(cartData);
            }
            else
            {
                cartData.CartProducts.Add(mapper.Map<CartProduct>(cart));
                repository.Update(cartData);
            }
            
            repository.SaveChanges();

            return cart;
        }

        public IEnumerable<CartDto> CartItems(int userId)
        {
            var cartData = repository.GetWithProduct(userId)?.CartProducts;

            return mapper.Map<IEnumerable<CartDto>>(cartData);
        }

        public bool DeleteFromCart(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
