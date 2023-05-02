using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DTOs.Payment;
using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var data = productService.GetProduct(id);

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

        [HttpPost, Authorize]
        public IActionResult Create(ProductCreateDto createDto)
        {
            try
            {
                return Ok(ServiceResponse.CreateResponse(true, "", productService.CreateProduct(createDto)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch, Authorize]
        public IActionResult Update(ProductUpdateDto product)
        {
            try
            {
                return Ok(ServiceResponse.CreateResponse(true, "", productService.UpdateProduct(product)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
