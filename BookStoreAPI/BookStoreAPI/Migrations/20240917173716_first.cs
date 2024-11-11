using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookSizes_BookSizeId",
                        column: x => x.BookSizeId,
                        principalTable: "BookSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Birthdate", "Name", "ProfileImageUrl" },
                values: new object[,]
                {
                    { new Guid("1066aab5-c9be-4c36-8944-06a7d5db32f1"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("d0fbc87f-dceb-4d18-bfac-af0a794b4d3c"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("815e4274-d888-4d43-a761-b13992edd1a7"), "Small" },
                    { new Guid("4f032330-1fbd-4486-9b1f-b5c0d326f8ca"), "Medium" },
                    { new Guid("8fbf32a1-0dde-41d6-8eec-e211524670fe"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("fc4e9f83-7a66-4c44-b76e-b7bcd4056560"), new Guid("1066aab5-c9be-4c36-8944-06a7d5db32f1"), new Guid("4f032330-1fbd-4486-9b1f-b5c0d326f8ca"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("831368d0-0911-4150-8000-e28ca54f01db"), new Guid("d0fbc87f-dceb-4d18-bfac-af0a794b4d3c"), new Guid("8fbf32a1-0dde-41d6-8eec-e211524670fe"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSizeId",
                table: "Books",
                column: "BookSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookSizes");
        }
    }
}
