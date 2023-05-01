using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.DTOs;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Enums;
using System.Text.Json;

namespace ShoppingCart.Application.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IMapper mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            this.scopeFactory = scopeFactory;
            this.mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = JsonSerializer.Deserialize<BaseMessageBusDto>(message);

            switch(eventType?.Event)
            {
                case EventType.PaymentPublished:
                    Console.WriteLine("--> Payment published event detected");
                    AddPayment(message);
                    break;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    break;
            }
        }

        private void AddPayment(string message)
        {
            using(var scope = scopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                var paymentPublishedData = JsonSerializer.Deserialize<PaymentMessageBusDto>(message);

                try
                {
                    var payment = mapper.Map<PaymentCreateDto>(paymentPublishedData);

                    if(!service.PaymentExist(s => s.OrderId == payment.OrderId))
                    {
                        service.CreatePayment(payment);
                        Console.WriteLine("--> Payment added");
                    }
                    else
                    {
                        Console.WriteLine("--> Payment already exists...");
                    }

                } catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add payment to DB {ex.Message}");
                }
            }
        }
    }
}
