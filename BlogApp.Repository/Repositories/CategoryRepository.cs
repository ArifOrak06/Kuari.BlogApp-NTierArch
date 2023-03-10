using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Repositories;
using BlogApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Category> GetCategoryByIdWithArticlesAsync(int categoryId)
        {
            var data = await _context.Categories.Include(x => x.Articles).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
            return data;
           
        }
    }
}
