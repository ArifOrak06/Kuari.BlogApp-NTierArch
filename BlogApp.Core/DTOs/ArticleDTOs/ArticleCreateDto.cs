using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DTOs
{
    public class ArticleCreateDto
    {
        public string Title { get; set; } // notNull, pk, identityColumn
        public string ContentSummary { get; set; } // notNull
        public string ContentMain { get; set; } // notNull
        public string Picture { get; set; }// nullable
        public int ViewCount { get; set; } // Makale gösterim sayısı // notNull
        public int CategoryId { get; set; }
    }
}
