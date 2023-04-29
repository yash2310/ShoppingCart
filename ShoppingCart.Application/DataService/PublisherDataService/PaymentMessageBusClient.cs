using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using ShoppingCart.Application.DataService.PublisherDataService.Interface;
using ShoppingCart.Application.DTOs.Payment;
using System.Text;
using System.Text.Json;

namespace ShoppingCart.Application.DataService.PublisherDataService
{
    public class PaymentMessageBusClient : IPaymentMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private IConnection connection;
        private IModel channel;

        public PaymentMessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"]),
            };

            try
            {
                connection = factory.CreateConnection();
                channel = connection.CreateModel();

                channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine("--> Connected to Message Bus...");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not connect to Message Bus: {ex.Message}");
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ Connection Shutdown");
        }

        public void PublishNewPayment(PaymentMessageBusDto paymentMessageBusDto)
        {
            var message = JsonSerializer.Serialize(paymentMessageBusDto);

            if (connection.IsOpen)
            {
                Console.WriteLine($"--> RabbitMQ Connection Open Sending Message.....");

                SendMessage(message);
            }
            else
            {
                Console.WriteLine($"--> RabbitMQ Connection Closed, Not Sending Message.....");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "trigger", routingKey: "", mandatory: true, basicProperties: null, body: body);

            Console.WriteLine($"--> We have send {message}");
        }

        public void Dispose()
        {
            Console.WriteLine("--> Message Bus Disposed");

            if (channel.IsOpen)
            {
                channel.Close();
                connection.Close();
            }
        }
    }
}
