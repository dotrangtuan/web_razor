using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace EF_RazorPage.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
            
            // thiết lập luật
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>()
                .RuleFor(a => a.Title, r => r.Lorem.Sentence(5,5))
                .RuleFor(a => a.Created, r => r.Date.Between(new DateTime(2023, 6, 1), new DateTime(2023, 8, 1)))
                .RuleFor(a => a.Content, r => r.Lorem.Paragraphs(2,7));

            for (int i = 0; i < 20; i++) {
                // tạo bản ghi ngẫu nhiên
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                table: "articles",
                columns: new[] {"Title", "Created", "Content"},
                values: new object[] {article.Title, article.Created, article.Content}
            );
            }
            
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
