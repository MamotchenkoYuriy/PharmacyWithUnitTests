using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.Repository;
using Core;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;
        public Repository(DataContext context)
        {
            _entities = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            //_context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
            _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindAll()
        {
            return _entities;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T GetByPrimaryKey(object key)
        {
            return _entities.Find(key);
        }
    }
}
