using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.ArticleDTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Core.UnitOfWork;
using BlogApp.Service.Mappings.AutoMapper;
using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services
{
    public class ArticleService : Service<Article, ArticleListDto, ArticleCreateDto, ArticleUpdateDto>, IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : base(articleRepository, unitOfWork) 
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ArticleWithCommentsDto>> GetArticleByIdWithCommentsAsync(int id)
        {
            var data = await this._articleRepository.GetByIdAsyncy(id);
            if (data == null)
            {
                return Response<ArticleWithCommentsDto>.Fail(404, $" {id}'ye sahip data bulunamamıştır.");
            }
            var entity = await this._articleRepository.GetArticleByIdWithCommentsAsync(id);
            var articleWithCommentsDto = ObjectMapper.Mapper.Map<ArticleWithCommentsDto>(entity);
            return Response<ArticleWithCommentsDto>.Success(articleWithCommentsDto,200);
        }
    }
}
