using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs
{
    public  class ArticleListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } // notNull, pk, identityColumn
        public string ContentSummary { get; set; } // notNull
        public string ContentMain { get; set; } // notNull
        public string Picture { get; set; }// nullable

        public int CategoryId { get; set; }
    }
}
