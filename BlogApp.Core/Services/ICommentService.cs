using BlogApp.Core.DTOs;
using BlogApp.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface ICommentService : IService<Comment,CommentListDto,CommentCreateDto,CommentUpdateDto>
    {
    }
}
