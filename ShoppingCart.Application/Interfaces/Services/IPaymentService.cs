using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System.Linq.Expressions;

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
