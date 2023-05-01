using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public UserStatus UserStatus { get; set; }
        public UserUpdateType updateType { get; set; }
        public string? RefreshToken { get; set; }
    }
}
