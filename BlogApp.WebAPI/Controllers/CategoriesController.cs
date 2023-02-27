using BlogApp.Core.DTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebAPI.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
     
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await this._categoryService.GetAllAsync();
            return CreateActionResult(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await this._categoryService.GetByIdAsync(id);
            return CreateActionResult(result);
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithArticles(int categoryId)
        {
            var result = await this._categoryService.GetCategoryByIdWithArticlesAsync(categoryId);
            return CreateActionResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var result = await this._categoryService.AddAsync(categoryCreateDto);
            return CreateActionResult(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await this._categoryService.UpdateAsync(categoryUpdateDto,categoryUpdateDto.Id);
            return CreateActionResult(result); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var result = await this._categoryService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
