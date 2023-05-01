using AutoMapper;
using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<UserReadDto, UserUpdateDto>().ReverseMap();
        }
    }
}
