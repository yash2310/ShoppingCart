using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Cart.Infra.Data;
using System.Linq.Expressions;

namespace ShoppingCart.Cart.Infra.Repositories
{
    public class Repository<T> : ICartRepository<T> where T : Domain.Entities.Cart
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> entities;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return entities.Any(expression);
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var data = entities.SingleOrDefault(expression);

            if (data != null)
            {
                entities.Remove(data);
            }
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return entities.SingleOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Domain.Entities.Cart? GetWithProduct(int userId)
        {
            return dbContext.Carts.Include(c => c.CartProducts).FirstOrDefault(c => c.UserId == userId);
        }
    }
}
