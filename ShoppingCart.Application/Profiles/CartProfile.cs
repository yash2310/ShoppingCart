using AutoMapper;
using ShoppingCart.Application.DTOs.Cart;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Profiles
{
    public class CartProfile: Profile
    {
        public CartProfile()
        {
            CreateMap<CartProduct, CartDto>().ReverseMap();
        }
    }
}
