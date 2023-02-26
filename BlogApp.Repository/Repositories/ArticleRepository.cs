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
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly BlogAppDbContext _context;
        public ArticleRepository(BlogAppDbContext context) : base(context) 
        {
            this._context = context;
        }

        public async Task<Article> GetArticleByIdWithCommentsAsync(int id)
        {
            var data = await this._context.Articles.Include(a => a.Comments).Where(c => c.Id == id).SingleOrDefaultAsync();
            return data;
        }
    }
}
