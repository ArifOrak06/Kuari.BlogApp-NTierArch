using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetByFilter(Expression<Func<T,bool>> predicate);
        Task<T> GetByIdAsyncy(int id);
        Task<T> AddAsync(T entity);   
  
        void Delete(T entity);
        void Update(T entity);

    }
}
