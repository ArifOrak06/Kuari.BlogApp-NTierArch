using BlogApp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Validations.CommentValidation
{
    public class CommentListDtoValidator : AbstractValidator<CommentListDto>
    {
        public CommentListDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.ContentMain).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.ArticleId).NotNull().WithMessage("{PropertyName} boş olamaz");
            RuleFor(x => x.ArticleId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 1 ve üzeri rakam olmalıdır.");
        }
    }
}
