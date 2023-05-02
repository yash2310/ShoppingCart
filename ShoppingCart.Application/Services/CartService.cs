using AutoMapper;
using ShoppingCart.Application.DTOs.Cart;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository<Cart> repository;
        private readonly IMapper mapper;

        public CartService(ICartRepository<Cart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<CartDto> CartItems(int userId)
        {
            var cartData = repository.GetWithProduct(userId)?.CartProducts;

            return mapper.Map<IEnumerable<CartDto>>(cartData);
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
                repository.SaveChanges();
            }

            return cart;
        }

        public CartDto UpdateCart(int userId, CartDto cart)
        {
            var cartData = repository.GetWithProduct(userId);

            if (cartData != null && cartData.CartProducts.Any())
            {
                foreach (var product in cartData.CartProducts)
                {
                    if (product.ProductId == cart.ProductId)
                    {
                        product.ProductQuantity = cart.ProductQuantity;
                    }
                }
                repository.Update(cartData);
            }

            repository.SaveChanges();

            return cart;
        }

        public bool DeleteFromCart(int userId, int productId)
        {
            var cartData = repository.GetWithProduct(userId);

            if (cartData != null && cartData.CartProducts.Any())
            {
                foreach (var product in cartData.CartProducts)
                {
                    if (product.ProductId == productId)
                    {
                        cartData.CartProducts.Remove(product);
                    }
                }
                repository.Update(cartData);
            }

            repository.SaveChanges();

            return true;
        }
    }
}
