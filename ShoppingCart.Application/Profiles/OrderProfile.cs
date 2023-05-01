using AutoMapper;
using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, OrderDetail>().ReverseMap();
            CreateMap<OrderReadDto, OrderDetail>().ReverseMap();
            CreateMap<PaymentMessageBusDto, OrderDetail>().ReverseMap();
        }
    }
}
