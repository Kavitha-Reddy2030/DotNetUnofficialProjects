using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("815e4274-d888-4d43-a761-b13992edd1a7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("831368d0-0911-4150-8000-e28ca54f01db"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("fc4e9f83-7a66-4c44-b76e-b7bcd4056560"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1066aab5-c9be-4c36-8944-06a7d5db32f1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d0fbc87f-dceb-4d18-bfac-af0a794b4d3c"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("4f032330-1fbd-4486-9b1f-b5c0d326f8ca"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("8fbf32a1-0dde-41d6-8eec-e211524670fe"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Birthdate", "Name", "ProfileImageUrl" },
                values: new object[,]
                {
                    { new Guid("c6a01f06-4305-48af-a914-c63308e14c81"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("9c7c598d-32fa-45a3-b779-757acee73ba9"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("55a5d60c-563d-48ba-8423-11242fb14969"), "Small" },
                    { new Guid("cf9ae29d-11f4-474d-9e58-adb5aeab3638"), "Medium" },
                    { new Guid("464dcb60-6354-4ed5-8b81-2b047486ac5e"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("10647064-8e5a-4d7a-af3c-612440871288"), new Guid("c6a01f06-4305-48af-a914-c63308e14c81"), new Guid("cf9ae29d-11f4-474d-9e58-adb5aeab3638"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("dcd35143-a106-4e6f-8e68-3c26026b152c"), new Guid("9c7c598d-32fa-45a3-b779-757acee73ba9"), new Guid("464dcb60-6354-4ed5-8b81-2b047486ac5e"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("55a5d60c-563d-48ba-8423-11242fb14969"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("10647064-8e5a-4d7a-af3c-612440871288"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dcd35143-a106-4e6f-8e68-3c26026b152c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("9c7c598d-32fa-45a3-b779-757acee73ba9"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c6a01f06-4305-48af-a914-c63308e14c81"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("464dcb60-6354-4ed5-8b81-2b047486ac5e"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("cf9ae29d-11f4-474d-9e58-adb5aeab3638"));

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
        }
    }
}
