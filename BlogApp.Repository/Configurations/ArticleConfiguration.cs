using BlogApp.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repository.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ContentMain).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.PublishDate).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.ViewCount).IsRequired();
            builder.Property(x => x.ContentSummary).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
        }
    }
}
