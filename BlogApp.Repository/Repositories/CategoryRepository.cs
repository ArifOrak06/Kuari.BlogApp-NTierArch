using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Repositories;
using BlogApp.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private readonly BlogAppDbContext _context;
        public CategoryRepository(BlogAppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
