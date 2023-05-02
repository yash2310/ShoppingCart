using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Common;
using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Enums;
using System.Security.Claims;

namespace ShoppingCart.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginDto)
        {
            var user = userService.GetUserForAuth(u =>
            u.Email == loginDto.Email &&
            u.Password == loginDto.Password &&
            u.IsActive == Domain.Enums.UserStatus.Active);

            if (user == null)
            {
                return NotFound(ServiceResponse.CreateResponse(false, "Invalid Username or Password", null));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken();

            var updateDto = mapper.Map<UserUpdateDto>(user);
            updateDto.RefreshToken = refreshToken;
            updateDto.updateType = UserUpdateType.Token;

            userService.UpdateUser(updateDto);

            var authData = new UserAuthDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return Ok(ServiceResponse.CreateResponse(true, null, authData));
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateDto createDto)
        {
            var user = userService.GetUser(u => u.Email == createDto.Email);

            if (user != null)
            {
                return BadRequest(ServiceResponse.CreateResponse(false, "User with the same email id already exist", null));
            }

            userService.CreateUser(createDto);

            return Ok(ServiceResponse.CreateResponse(true, "User registered successfully", null));
        }
    }
}
