using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Repository.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Yazılım Bilimi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Yer Bilimi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tıp Bilimi" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ContentMain", "ContentSummary", "Picture", "PublishDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, "Yazılım ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları", "Yazılıma dair herşey", "1.jpeg", new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2021), "Yazılım Özgürleştirir", 0 },
                    { 2, 1, "Frontend teknolojileri ve front ile ilgili merak ettiğiniz alanlar,teknolojiler ve yol haritaları", "Frontend seviyelerine ve kullanılan teknolojilere dair herşey", "2.jpeg", new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2038), "Frontendte Mini Backenddir Aslında", 0 },
                    { 3, 2, "Jeoloji alanı ve Deprem bilimi ile ilgili her şeyden detaylıca anlatılacaktır.", "Deprem tetikleyen faktörler", "3.jpeg", new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2041), "Ülkemizde Deprem Bilimi", 0 },
                    { 4, 3, "Kalp sağlığı ile ilgili herşeyin detaylıca anlatıldığı bir makale olacak.", "Kalp Sağlı için öncelikle yapılması gereken hususlar", "4.jpeg", new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2044), "Kalp eşittir Ben", 0 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "ContentMain", "Name", "PublishDate" },
                values: new object[] { 1, 1, "Bu makale yazılıma yeni başlayacak olan insanlar için harika bir klavuz olacağından şüphem yok, teşekkürler.", "Kübra Ardahanlıoğlu ORAK", new DateTime(2023, 2, 27, 22, 28, 41, 452, DateTimeKind.Local).AddTicks(2775) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
