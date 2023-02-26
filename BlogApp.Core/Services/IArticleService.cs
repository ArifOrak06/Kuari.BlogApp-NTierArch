using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.ArticleDTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface IArticleService : IService<Article,ArticleListDto,ArticleCreateDto,ArticleUpdateDto>
    {
  
        Task<Response<ArticleWithCommentsDto>> GetArticleByIdWithCommentsAsync(int id);
    }
}
