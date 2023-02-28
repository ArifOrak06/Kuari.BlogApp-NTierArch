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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly BlogAppDbContext _context;
        public CommentRepository(BlogAppDbContext context) : base(context) 
        {
            _context = context;
        }

      
    }
}
