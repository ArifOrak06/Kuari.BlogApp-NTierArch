using BlogApp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Validations.CategoryValidation
{
    public class CategoryListDtoValidator : AbstractValidator<CategoryListDto>
    {
        public CategoryListDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} boş olamaz");
        }
    }
}
