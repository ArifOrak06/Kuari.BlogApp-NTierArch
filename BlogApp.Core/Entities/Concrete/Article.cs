using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities.Concrete
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } // notNull, pk, identityColumn
        public string ContentSummary { get; set; } // notNull
        public string ContentMain { get; set; } // notNull
        public DateTime PublishDate { get; set; }// notNull
        public string Picture { get; set; }// nullable
        public int ViewCount { get; set; } // Makale gösterim sayısı // notNull
        public int CategoryId { get; set; }// notNull
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
