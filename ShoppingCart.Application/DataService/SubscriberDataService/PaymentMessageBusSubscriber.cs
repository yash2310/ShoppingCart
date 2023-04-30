using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShoppingCart.Application.EventProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DataService.SubscriberDataService
{
    public class PaymentMessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IEventProcessor eventProcessor;
        private readonly IHostingEnvironment hostingEnvironment;
        private IConnection connection;
        private IModel channel;
        private string queueName;

        public PaymentMessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor, IHostingEnvironment hostingEnvironment)
        {
            this.configuration = configuration;
            this.eventProcessor = eventProcessor;
            this.hostingEnvironment = hostingEnvironment;

            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQHost"],
                Port = int.Parse(configuration["RabbitMQPort"]),
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

            queueName = channel.QueueDeclare().QueueName;

            channel.QueueBind(queue: queueName, exchange: "trigger", routingKey: "");

            Console.WriteLine("--> Listening on the Message Bus");

            connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> Connection Shutdown");
        }

        public override void Dispose()
        {
            if (channel.IsOpen)
            {
                channel.Close();
                connection.Close();
            }

            base.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("--> Event Received");
                var body = ea.Body;
                var notificationBody = Encoding.UTF8.GetString(body.ToArray());

                eventProcessor.ProcessEvent(notificationBody);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
