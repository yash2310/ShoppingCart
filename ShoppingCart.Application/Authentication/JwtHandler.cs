using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Application.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Application.Authentication
{
    public static class JwtHandler
    {
        public static TokenValidationParameters GetValidationParameter(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        }
    }
}