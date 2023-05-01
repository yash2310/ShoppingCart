namespace ShoppingCart.Application.DTOs.User
{
    public class UserAuthDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
