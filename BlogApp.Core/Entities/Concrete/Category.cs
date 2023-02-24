using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
