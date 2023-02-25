using BlogApp.Core.Repositories;
using BlogApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BlogAppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(BlogAppDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
            return entity;

        }


        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await this._dbSet.ToListAsync();
            return entities;
        }

        public IQueryable<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where(predicate);

        }

        public async Task<T> GetByIdAsyncy(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }
    }
}
