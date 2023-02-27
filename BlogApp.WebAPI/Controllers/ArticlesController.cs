using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.ArticleDTOs;
using BlogApp.Core.Services;
using BlogApp.SharedLibrary.ResponseDTOs;
using BlogApp.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebAPI.Controllers
{
 
    public class ArticlesController : CustomBaseController
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var result = await this._articleService.GetAllAsync();
            return CreateActionResult<IEnumerable<ArticleListDto>>(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var result = await this._articleService.GetByIdAsync(id);
            return CreateActionResult<ArticleListDto>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleByIdWithComments(int id)
        {
            var result = await this._articleService.GetArticleByIdWithCommentsAsync(id);
            return CreateActionResult<ArticleWithCommentsDto>(result);
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateDto createDto)
        {
            var result = await this._articleService.AddAsync(createDto);
            return CreateActionResult<ArticleCreateDto>(result);

        }
        [HttpPut]
        public async Task<IActionResult> Update(ArticleUpdateDto updateDto)
        {
            var result = await this._articleService.UpdateAsync(updateDto,updateDto.Id);
            return CreateActionResult<ArticleUpdateDto>(result);
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await this._articleService.DeleteAsync(id);
            return CreateActionResult<NoDataDto>(result);
        }
    }
}
