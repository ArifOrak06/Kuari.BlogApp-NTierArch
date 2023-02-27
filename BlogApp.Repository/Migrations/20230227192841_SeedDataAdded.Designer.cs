﻿// <auto-generated />
using System;
using BlogApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogApp.Repository.Migrations
{
    [DbContext(typeof(BlogAppDbContext))]
    [Migration("20230227192841_SeedDataAdded")]
    partial class SeedDataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ContentMain")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ContentSummary")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ContentMain = "Yazılım ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları",
                            ContentSummary = "Yazılıma dair herşey",
                            Picture = "1.jpeg",
                            PublishDate = new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2021),
                            Title = "Yazılım Özgürleştirir",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ContentMain = "Frontend teknolojileri ve front ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları",
                            ContentSummary = "Frontend seviyelerine ve kullanılan teknolojilere dair herşey",
                            Picture = "2.jpeg",
                            PublishDate = new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2038),
                            Title = "Frontendte Mini Backenddir Aslında",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            ContentMain = "Jeoloji alanı ve Deprem bilimi ile ilgili her şeyden detaylıca anlatılacaktır.",
                            ContentSummary = "Deprem tetikleyen faktörler",
                            Picture = "3.jpeg",
                            PublishDate = new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2041),
                            Title = "Ülkemizde Deprem Bilimi",
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            ContentMain = "Kalp sağlığı ile ilgili herşeyin detaylıca anlatıldığı bir makale olacak.",
                            ContentSummary = "Kalp Sağlı için öncelikle yapılması gereken hususlar",
                            Picture = "4.jpeg",
                            PublishDate = new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2044),
                            Title = "Kalp eşittir Ben",
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yazılım Bilimi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yer Bilimi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tıp Bilimi"
                        });
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("ContentMain")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            ContentMain = "Bu makale yazılıma yeni başlayacak olan insanlar için harika bir klavuz olacağından şüphem yok, teşekkürler.",
                            Name = "Kübra Ardahanlıoğlu ORAK",
                            PublishDate = new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2775)
                        });
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Article", b =>
                {
                    b.HasOne("BlogApp.Core.Entities.Concrete.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("BlogApp.Core.Entities.Concrete.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BlogApp.Core.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
