using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Application.Interfaces.Services;

namespace ShoppingCart.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public TokenController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(UserAuthDto userAuthDto)
        {
            if (userAuthDto == null)
            {
                return BadRequest(ServiceResponse.CreateResponse(false, "Invalid client request", null));
            }

            var claimPrincipal = tokenService.GetPrincipalFromToken(userAuthDto.AccessToken);
            var username = claimPrincipal.Identity?.Name;

            var user = userService.GetUserForAuth(u => u.Email == username);

            if (user == null || user.RefreshToken != userAuthDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest(ServiceResponse.CreateResponse(false, "Invalid client request", null));

            var accessToken = tokenService.GenerateAccessToken(claimPrincipal.Claims);
            var refreshToken = tokenService.GenerateRefreshToken();
           
            var userUpdateDto = mapper.Map<UserUpdateDto>(user);

            userUpdateDto.RefreshToken = refreshToken;
            userUpdateDto.updateType = Domain.Enums.UserUpdateType.Token;

            userService.UpdateUser(userUpdateDto);

            return Ok(new UserAuthDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpGet("revoke"), Authorize]
        public IActionResult Revoke()
        {
            var username = User.Identity?.Name;
            var user = userService.GetUserForAuth(u => u.Email == username);
            if (user == null) return BadRequest();

            var userUpdateDto = mapper.Map<UserUpdateDto>(user);

            userUpdateDto.RefreshToken = null;
            userUpdateDto.updateType = Domain.Enums.UserUpdateType.Token;

            userService.UpdateUser(userUpdateDto);

            return Ok();
        }
    }
}
