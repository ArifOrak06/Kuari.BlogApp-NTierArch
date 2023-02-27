using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.CategoryDTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface ICategoryService : IService<Category,CategoryListDto,CategoryCreateDto,CategoryUpdateDto>
    {
        Task<CustomResponseDto<CategoryWithArticleDto>> GetCategoryByIdWithArticlesAsync(int categoryId);
    }
}
