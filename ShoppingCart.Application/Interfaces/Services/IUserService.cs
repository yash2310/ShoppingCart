using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IUserService
    {
        UserReadDto CreateUser(UserCreateDto createDto);
        IEnumerable<UserReadDto> GetUsers();
        UserReadDto GetUser(Expression<Func<User, bool>> expression);
        User GetUserForAuth(Expression<Func<User, bool>> expression);
        UserReadDto UpdateUser(UserUpdateDto updateDto);
    }
}
