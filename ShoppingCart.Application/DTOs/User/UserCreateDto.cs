using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs.User
{
    public class UserCreateDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public UserRole UserRole { get; set; }
        public UserStatus IsActive { get; set; }
    }
}
