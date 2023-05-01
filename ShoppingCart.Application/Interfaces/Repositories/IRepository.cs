using System.Linq.Expressions;

namespace ShoppingCart.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
