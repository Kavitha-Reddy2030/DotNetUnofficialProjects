using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookFilterAPI.Migrations
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
                    { new Guid("c906e0f8-0a71-40f1-b4c7-9f9f3bdd7cf7"), "Bio of New Author 1.", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 1", "https://example.com/images/new_author_1.jpg" },
                    { new Guid("3ef4e266-20d0-432e-89ff-ad60c9b5ff78"), "Bio of New Author 2.", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 2", "https://example.com/images/new_author_2.jpg" },
                    { new Guid("e62092c5-8856-4906-a686-98e5434c7fc8"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("0b8ea859-2a6b-40fa-abb8-ddad2edba051"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("a056b77e-f6b4-4c85-9948-54fa570f7c24"), "Extra Small" },
                    { new Guid("ce3a9bdb-c1b2-4ce1-9313-0a4bd8a7a183"), "Extra Large" },
                    { new Guid("2b719459-a057-46e8-8390-953b11a6afda"), "Small" },
                    { new Guid("5b78e4b7-c0d7-4840-b985-c0445c38f2d0"), "Medium" },
                    { new Guid("9872312a-5fc7-4c3d-9ffe-c2def97b2856"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("c8c52296-051c-4afe-b6b9-d43db1a42781"), new Guid("c906e0f8-0a71-40f1-b4c7-9f9f3bdd7cf7"), new Guid("a056b77e-f6b4-4c85-9948-54fa570f7c24"), "https://example.com/images/new_book_1.jpg", "Description for New Book 1.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 1" },
                    { new Guid("827662ca-0989-45cf-b063-3aea16c1acbd"), new Guid("3ef4e266-20d0-432e-89ff-ad60c9b5ff78"), new Guid("ce3a9bdb-c1b2-4ce1-9313-0a4bd8a7a183"), "https://example.com/images/new_book_2.jpg", "Description for New Book 2.", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 2" },
                    { new Guid("14ec2ced-0b14-4c55-8c8e-76c408c326dd"), new Guid("e62092c5-8856-4906-a686-98e5434c7fc8"), new Guid("5b78e4b7-c0d7-4840-b985-c0445c38f2d0"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("c47a2160-8c0e-459e-8efe-44de15f1dc07"), new Guid("0b8ea859-2a6b-40fa-abb8-ddad2edba051"), new Guid("9872312a-5fc7-4c3d-9ffe-c2def97b2856"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" }
                });

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
