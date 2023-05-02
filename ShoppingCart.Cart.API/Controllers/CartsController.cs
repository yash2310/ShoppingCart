using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DTOs.Cart;
using ShoppingCart.Application.Interfaces.Services;

namespace ShoppingCart.Cart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly ITokenService tokenService;
        private string accessToken = string.Empty;

        public CartsController(ICartService cartService, ITokenService tokenService)
        {
            this.cartService = cartService;
            this.tokenService = tokenService;
        }

        [HttpGet("products"), Authorize]
        public IActionResult Get()
        {
            accessToken = Request.Headers.Authorization[0].Replace("Bearer ", "");
            var currentUser = tokenService.GetCurrentUser(accessToken);

            var carts = cartService.CartItems(currentUser.UserId);

            return Ok(carts);
        }

        [HttpPost("add"), Authorize]
        public IActionResult Add(CartDto cart)
        {
            accessToken = Request.Headers.Authorization[0].Replace("Bearer ", "");
            var currentUser = tokenService.GetCurrentUser(accessToken);

            var data = cartService.AddToCart(currentUser.UserId, cart);

            return Ok(ServiceResponse.CreateResponse(true, "", data));
        }

        [HttpPost("update"), Authorize]
        public IActionResult Update(CartDto cart)
        {
            accessToken = Request.Headers.Authorization[0].Replace("Bearer ", "");
            var currentUser = tokenService.GetCurrentUser(accessToken);

            var data = cartService.UpdateCart(currentUser.UserId, cart);

            return Ok(ServiceResponse.CreateResponse(true, "", data));
        }

        [HttpPost("delete"), Authorize]
        public IActionResult Delete(CartDto cart)
        {
            accessToken = Request.Headers.Authorization[0].Replace("Bearer ", "");
            var currentUser = tokenService.GetCurrentUser(accessToken);

            cartService.DeleteFromCart(currentUser.UserId, cart.ProductId);

            return Ok(ServiceResponse.CreateResponse(true, "", null));
        }
    }
}
