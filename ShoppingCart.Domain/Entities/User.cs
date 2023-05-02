using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public string Role { get; set; } = string.Empty;
        public UserStatus IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
