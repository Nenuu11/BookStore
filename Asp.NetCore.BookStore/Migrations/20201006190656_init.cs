using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.NetCore.BookStore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    CopiesNumber = table.Column<int>(nullable: false),
                    BorrowedCopies = table.Column<int>(nullable: false),
                    CopiesLeft = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowedCopies", "CopiesLeft", "CopiesNumber", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "j.d.salinger", 4, 2, 6, "the catcher in the rye", 3.1f },
                    { 2, "harper lee", 1, 4, 5, "to kill a mockingbird", 4.2f },
                    { 3, "jane austen", 2, 5, 7, "pride and prejudice", 4.9f },
                    { 4, "j. k. rowling", 1, 3, 4, "harry potter and the philosopher's stone", 4.8f },
                    { 5, "wiiliam shakespeare", 0, 3, 3, "hamlet", 4.6f },
                    { 6, "wiiliam shakespeare", 0, 3, 3, "othelo", 4.4f },
                    { 7, "john green", 0, 5, 5, "the fault in our stars", 3.4f },
                    { 8, "hilary mantelr", 0, 3, 3, "wolf hall", 3.9f },
                    { 9, "yann martel", 1, 3, 4, "life of pi", 4f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
