using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepository<T> where T : class 
    {
        void Add(T entity);
        void Remove(T entity); 
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> preficate );
        void SaveChanges();
        T GetByPrimaryKey(object key);
    }
}
