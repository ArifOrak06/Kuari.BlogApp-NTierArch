using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs
{
    public class CommentListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }// notNull, pk, useIdentityColumn, maxLength(100)
        public string ContentMain { get; set; }// notNull
        public int ArticleId { get; set; }
    }
}
