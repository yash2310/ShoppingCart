using AutoMapper;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System.Linq.Expressions;

namespace ShoppingCart.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> repository;
        private readonly IMapper mapper;

        public PaymentService(IRepository<Payment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public PaymentReadDto CreatePayment(PaymentCreateDto createDto)
        {
            var payment = mapper.Map<Payment>(createDto);

            repository.Add(payment);

            var paymentRead = mapper.Map<PaymentReadDto>(payment);

            return paymentRead;
        }

        public PaymentReadDto? GetPayment(int paymentId)
        {
            var payment = repository.Get(p => p.Id == paymentId);

            if (payment != null)
                return mapper.Map<PaymentReadDto>(payment);

            return null;
        }

        public bool PaymentExist(Expression<Func<Payment, bool>> expression)
        {
            return repository.Any(expression);
        }

        public PaymentReadDto? UpdatePayment(int paymentId, PaymentStatus status)
        {
            var payment = repository.Get(p => p.Id == paymentId);

            if (payment != null)
            {
                payment.Status = status;
                payment.UpdatedOn = DateTime.Now;

                repository.Update(payment);

                var paymentRead = mapper.Map<PaymentReadDto>(payment);

                return paymentRead;
            }

            return null;
        }
    }
}
