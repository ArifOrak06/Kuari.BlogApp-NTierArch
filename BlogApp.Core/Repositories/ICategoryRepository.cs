using BlogApp.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByIdWithArticlesAsync(int categoryId);
    }
}
