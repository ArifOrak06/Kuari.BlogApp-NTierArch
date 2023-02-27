using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs.CategoryDTOs
{
    public class CategoryWithArticleDto : CategoryListDto
    {
        public List<ArticleListDto> Articles { get; set; }
    }
}
