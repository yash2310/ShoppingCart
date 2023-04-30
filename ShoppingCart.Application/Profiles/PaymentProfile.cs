using AutoMapper;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Profiles
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateDto, Payment>().ReverseMap();
            CreateMap<PaymentReadDto, Payment>().ReverseMap();
            CreateMap<PaymentMessageBusDto, PaymentCreateDto>().ReverseMap();
        }
    }
}
