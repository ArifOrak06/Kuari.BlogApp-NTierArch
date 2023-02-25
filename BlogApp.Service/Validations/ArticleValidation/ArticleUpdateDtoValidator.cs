using BlogApp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Validations.ArticleValidation
{
    public class ArticleUpdateDtoValidator : AbstractValidator<ArticleUpdateDto>
    {
        public ArticleUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 1'den büyük rakam  olması gerekmektedir.");
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.ContentMain).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.Picture).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.ContentSummary).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 1'den büyük rakam  olması gerekmektedir.");

        }
    }
}
