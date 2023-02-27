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
    public class ArticleSeedData : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article[]
            {
                new(){Id=1,ContentMain="Yazılım ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları",ContentSummary="Yazılıma dair herşey",Picture="1.jpeg",Title = "Yazılım Özgürleştirir",PublishDate = DateTime.Now,CategoryId=1},
                new(){Id=2,ContentMain="Frontend teknolojileri ve front ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları",ContentSummary="Frontend seviyelerine ve kullanılan teknolojilere dair herşey",Picture="2.jpeg",Title = "Frontendte Mini Backenddir Aslında",PublishDate = DateTime.Now,CategoryId=1},
                new(){Id=3,ContentMain="Jeoloji alanı ve Deprem bilimi ile ilgili her şeyden detaylıca anlatılacaktır.",ContentSummary="Deprem tetikleyen faktörler",Picture="3.jpeg",Title = "Ülkemizde Deprem Bilimi",PublishDate = DateTime.Now,CategoryId=2},
                new(){Id=4,ContentMain="Kalp sağlığı ile ilgili herşeyin detaylıca anlatıldığı bir makale olacak.",ContentSummary="Kalp Sağlı için öncelikle yapılması gereken hususlar",Picture="4.jpeg",Title = "Kalp eşittir Ben",PublishDate = DateTime.Now,CategoryId=3},
            });
        }
    }
}
