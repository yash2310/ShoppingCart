using AutoMapper;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Profiles
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateDto, Payment>().ReverseMap();
            CreateMap<PaymentReadDto, Payment>().ReverseMap();
        }
    }
}
