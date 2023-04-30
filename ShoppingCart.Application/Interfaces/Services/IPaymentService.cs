using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        PaymentReadDto CreatePayment(PaymentCreateDto createDto);
        PaymentReadDto? GetPayment(int paymentId);
        PaymentReadDto? UpdatePayment(int paymentId, PaymentStatus status);
        bool PaymentExist(Expression<Func<Payment, bool>> expression);
    }
}
