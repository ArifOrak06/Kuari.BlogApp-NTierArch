using AutoMapper;
using BlogApp.Core.DTOs;
using BlogApp.Core.DTOs.ArticleDTOs;
using BlogApp.Core.Entities.Concrete;

namespace BlogApp.Service.Mappings.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
           
            CreateMap<CommentCreateDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
            CreateMap<CommentListDto, Comment>().ReverseMap();
            CreateMap<ArticleCreateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleListDto, Article>().ReverseMap();
            CreateMap<ArticleWithCommentsDto, Article>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryListDto, Category>().ReverseMap();

        }
    }
}
