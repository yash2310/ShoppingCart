using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DataService.PublisherDataService.Interface;
using ShoppingCart.Application.DTOs.Order;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IPaymentMessageBusClient messageBusClient;

        public OrdersController(IOrderService orderService, IPaymentMessageBusClient messageBusClient)
        {
            this.orderService = orderService;
            this.messageBusClient = messageBusClient;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(orderService.GetOrders());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = orderService.GetOrder(id);

                if (data == null)
                {
                    return NotFound(ServiceResponse.CreateResponse(true, "No Data Found", null));
                }

                return Ok(ServiceResponse.CreateResponse(true, "", data));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(OrderCreateDto createDto)
        {
            try
            {
                var order = orderService.CreateOrder(createDto);

                var messageBusDto = new PaymentMessageBusDto
                {
                    OrderId = order.Id,
                    Amount = order.TotalAmount,
                    Email = "abc@abc.com",
                    Event = "Payment Published",
                    Status = PaymentStatus.Pending
                };

                messageBusClient.PublishNewPayment(messageBusDto);

                return Ok(orderService.CreateOrder(createDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, OrderStatus status)
        {
            try
            {
                return Ok(orderService.UpdateOrder(id, status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
