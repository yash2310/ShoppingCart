using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Payment.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Payment.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;
        private DbSet<T> entities;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            entities.Add(entity);
            dbContext.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return entities.Any(expression);
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entity = entities.SingleOrDefault(expression);
            if (entity != null)
            {
                entities.Remove(entity);
            }

            dbContext.SaveChanges();
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
            dbContext.SaveChanges();
        }
    }
}
