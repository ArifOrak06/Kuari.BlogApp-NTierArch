using BlogApp.Core.UnitOfWork;
using BlogApp.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppDbContext _context;

        public UnitOfWork(BlogAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
