using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Interfaces.Repositories
{
    public interface ICartRepository<T> : IRepository<T>
    {
        Cart? GetWithProduct(int userId);
    }
}
