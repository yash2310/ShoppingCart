using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, ITokenService tokenService, IConfiguration configuration, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost("login")] 
        public IActionResult Login(UserLoginDto loginDto)
        {
            var user = userService.GetUser(u =>
            u.Email == loginDto.Email &&
            u.Password == loginDto.Password &&
            u.IsActive == Domain.Enums.UserStatus.Active);

            if(user == null)
            {
                return NotFound();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken();

            var updateDto = mapper.Map<UserUpdateDto>(user);
            updateDto.RefreshToken = refreshToken;
            updateDto.updateType = Domain.Enums.UserUpdateType.Token;

            userService.UpdateUser(updateDto);

            var authData = new UserAuthDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return Ok(authData);
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateDto createDto)
        {
            var user = userService.GetUser(u => u.Email == createDto.Email);

            if (user != null)
            {
                return BadRequest("User with the same email id already exist");
            }

            userService.CreateUser(createDto);

            return Ok();
        }
    }
}
