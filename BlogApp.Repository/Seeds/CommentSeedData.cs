using BlogApp.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Seeds
{
    public class CommentSeedData : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new Comment[]
            {
                new(){Id=1, Name="Kübra Ardahanlıoğlu ORAK", ArticleId=1,ContentMain="Bu makale yazılıma yeni başlayacak olan insanlar için harika bir klavuz olacağından şüphem yok, teşekkürler.",PublishDate = DateTime.Now}
            });
        }
    }
}
