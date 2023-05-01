using AutoMapper;
using ShoppingCart.Application.DTOs.User;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Enums;
using System.Linq.Expressions;

namespace ShoppingCart.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public UserReadDto CreateUser(UserCreateDto createDto)
        {
            if(createDto.Password != createDto.ConfirmPassword)
            {
                throw new ArgumentException("Password and Confirm Passsword Should be Same");
            }

            var user = mapper.Map<User>(createDto);

            repository.Add(user);
            repository.SaveChanges();

            var userReadDto = mapper.Map<UserReadDto>(user);

            return userReadDto;
        }

        public UserReadDto GetUser(Expression<Func<User, bool>> expression)
        {
            var user = mapper.Map<UserReadDto>(repository.Get(expression));
            return user;
        }

        public User GetUserForAuth(Expression<Func<User, bool>> expression)
        {
            return repository.Get(expression);
        }

        public IEnumerable<UserReadDto> GetUsers()
        {
            var users = repository.GetAll();

            return mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public UserReadDto UpdateUser(UserUpdateDto updateDto)
        {
            var user = repository.Get(u => u.Id == updateDto.Id);

            if (user != null)
            {
                switch (updateDto.updateType)
                {
                    case UserUpdateType.Password:
                        user.Password = updateDto.NewPassword;
                        break;
                    case UserUpdateType.Status:
                        user.IsActive = updateDto.UserStatus;
                        break;
                    case UserUpdateType.Detail:
                        user.Firstname = updateDto.Firstname;
                        user.Lastname = updateDto.Firstname;
                        user.Address = updateDto.Firstname;
                        break;
                    case UserUpdateType.Token:
                        user.RefreshToken = updateDto.RefreshToken;
                        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                        break;
                    default:
                        break;
                }

                repository.Update(user);
                repository.SaveChanges();

                return mapper.Map<UserReadDto>(user);
            }

            return null;
        }
    }
}
