using BlogApp.Core.DTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Core.UnitOfWork;
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




    }
}
