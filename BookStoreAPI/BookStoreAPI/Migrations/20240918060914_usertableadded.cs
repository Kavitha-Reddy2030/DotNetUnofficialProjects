using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class usertableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Birthdate", "Name", "ProfileImageUrl" },
                values: new object[,]
                {
                    { new Guid("9cab78d0-c547-47c3-b450-6dfbcb647fc1"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("ddf3ed94-999b-46d1-b978-48b585d4b1b4"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("13b39c6a-8e52-43cd-8207-6fdc11b39e48"), "Small" },
                    { new Guid("fb587b8f-9419-4a30-a689-a605456512f1"), "Medium" },
                    { new Guid("b4ee2a33-ac64-4443-bf6f-195fe6d4a38c"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("ed4e4b1b-8166-4f6c-8d4e-def2ecf56270"), "admin123", "Admin", "admin" },
                    { new Guid("159830c3-3722-41ef-aa54-6b3eee83977f"), "user123", "User", "user1" },
                    { new Guid("2b16f919-1421-461d-87ab-83bd2cab8ecc"), "user234", "User", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("1fad1615-3190-4fa4-9ec2-cf0a8f7dcef1"), new Guid("9cab78d0-c547-47c3-b450-6dfbcb647fc1"), new Guid("fb587b8f-9419-4a30-a689-a605456512f1"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[] { new Guid("9d49e5d8-9a0b-4934-808d-9372df3a320f"), new Guid("ddf3ed94-999b-46d1-b978-48b585d4b1b4"), new Guid("b4ee2a33-ac64-4443-bf6f-195fe6d4a38c"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("13b39c6a-8e52-43cd-8207-6fdc11b39e48"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1fad1615-3190-4fa4-9ec2-cf0a8f7dcef1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9d49e5d8-9a0b-4934-808d-9372df3a320f"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("9cab78d0-c547-47c3-b450-6dfbcb647fc1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ddf3ed94-999b-46d1-b978-48b585d4b1b4"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("b4ee2a33-ac64-4443-bf6f-195fe6d4a38c"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("fb587b8f-9419-4a30-a689-a605456512f1"));

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
    }
}
