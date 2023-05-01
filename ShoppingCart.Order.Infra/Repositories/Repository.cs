using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Order.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Order.Infra.Repositories
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
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
    }
}
