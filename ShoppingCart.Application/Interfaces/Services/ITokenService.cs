using ShoppingCart.Application.Common;
using System.Security.Claims;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromToken(string token);
        CurrentUser GetCurrentUser(string token);
    }
}
