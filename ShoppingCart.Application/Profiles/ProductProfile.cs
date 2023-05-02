using AutoMapper;
using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
