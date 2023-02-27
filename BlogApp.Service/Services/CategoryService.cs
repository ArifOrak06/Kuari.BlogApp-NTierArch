using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.CategoryDTOs;
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
    public class CategoryService : Service<Category,CategoryListDto,CategoryCreateDto,CategoryUpdateDto>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : base(categoryRepository, unitOfWork)
        {
            this._categoryRepository= categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<CategoryWithArticleDto>> GetCategoryByIdWithArticlesAsync(int categoryId)
        {
            var data = await _categoryRepository.GetByIdAsyncy(categoryId);
            if (data == null)
            {
                return CustomResponseDto<CategoryWithArticleDto>.Fail(404,$"Belirtilen {categoryId}'ye sahip kategori bulunmamaktadır.");
            }
            var entity = await this._categoryRepository.GetCategoryByIdWithArticlesAsync(categoryId);
            var categoryWithArticleDto = ObjectMapper.Mapper.Map<CategoryWithArticleDto>(entity);
            return CustomResponseDto<CategoryWithArticleDto>.Success(200, categoryWithArticleDto);

        }
    }
}
