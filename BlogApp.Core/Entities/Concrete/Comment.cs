using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }// notNull, pk, useIdentityColumn, maxLength(100)
        public string ContentMain { get; set; }// notNull
        public DateTime PublishDate { get; set; }// notNull
        public int ArticleId { get; set; }// notNull
        public Article Article { get; set; }
    }
}
