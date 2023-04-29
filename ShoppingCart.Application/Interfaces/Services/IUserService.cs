using ShoppingCart.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IUserService
    {
        bool CreateUser(UserCreateDto createDto);
        IEnumerable<UserReadDto> GetUsers();
        UserReadDto GetUser(int userId);
        UserReadDto UpdateUser(int id, string address);
    }
}
