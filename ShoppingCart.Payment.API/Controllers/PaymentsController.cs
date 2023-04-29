using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Enums;
using System.Net;

namespace ShoppingCart.Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = paymentService.GetPayment(id);

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
        public IActionResult Create(PaymentCreateDto createDto)
        {
            try
            {
                return Ok(paymentService.CreatePayment(createDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, PaymentStatus status)
        {
            try
            {
                return Ok(paymentService.UpdatePayment(id, status));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
