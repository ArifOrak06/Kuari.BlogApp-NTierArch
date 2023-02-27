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
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category[]
            {
                new(){Id=1,Name="Yazılım Bilimi"},
                new(){Id=2,Name="Yer Bilimi"},
                new(){Id=3,Name="Tıp Bilimi"}
            });
        }
    }
}
