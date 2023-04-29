using AutoMapper;
using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
