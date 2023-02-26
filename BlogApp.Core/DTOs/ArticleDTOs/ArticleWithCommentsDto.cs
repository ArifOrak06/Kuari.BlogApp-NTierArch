using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs.ArticleDTOs
{
    public class ArticleWithCommentsDto : ArticleListDto
    {
        public List<CommentListDto> Comments { get; set; }
    }
}
