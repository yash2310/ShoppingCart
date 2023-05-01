using ShoppingCart.Domain.Enums;

namespace ShoppingCart.Application.DTOs.User
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int MobileNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
