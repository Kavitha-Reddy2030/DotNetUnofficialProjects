using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("159830c3-3722-41ef-aa54-6b3eee83977f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b16f919-1421-461d-87ab-83bd2cab8ecc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed4e4b1b-8166-4f6c-8d4e-def2ecf56270"));

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
                    { new Guid("677a3bef-de3a-4793-a29e-11c8c67558be"), "Bio of New Author 1.", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 1", "https://example.com/images/new_author_1.jpg" },
                    { new Guid("f1c15e2c-d7e1-4749-93de-f5dfc70c8683"), "Bio of New Author 2.", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 2", "https://example.com/images/new_author_2.jpg" },
                    { new Guid("30a4c9aa-31cb-4778-b689-d06f5861e29d"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("86000898-3458-4b01-af56-e0eb847e1df7"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("3ddbecc2-7aca-41b5-8546-12beb52b558d"), "Extra Small" },
                    { new Guid("f943cdf3-03ef-41fc-8132-6a6809089ecd"), "Extra Large" },
                    { new Guid("7c5d0e98-5e6d-44ea-8142-40d48eb7c4dc"), "Small" },
                    { new Guid("38d061fc-cb18-4cc4-95d3-4e3bd808dd6d"), "Medium" },
                    { new Guid("8eb8ce4c-0bde-4eac-8d3c-e9e60585d211"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("062ec03e-b980-40d2-83a2-7fe2e887449e"), new Guid("677a3bef-de3a-4793-a29e-11c8c67558be"), new Guid("3ddbecc2-7aca-41b5-8546-12beb52b558d"), "https://example.com/images/new_book_1.jpg", "Description for New Book 1.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 1" },
                    { new Guid("c9b2113a-0e0e-440a-9291-20f2ab5e61e6"), new Guid("f1c15e2c-d7e1-4749-93de-f5dfc70c8683"), new Guid("f943cdf3-03ef-41fc-8132-6a6809089ecd"), "https://example.com/images/new_book_2.jpg", "Description for New Book 2.", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 2" },
                    { new Guid("63673bd3-4550-43ef-ac3a-812a7ad35ce9"), new Guid("30a4c9aa-31cb-4778-b689-d06f5861e29d"), new Guid("38d061fc-cb18-4cc4-95d3-4e3bd808dd6d"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("a7bda68d-7372-4d81-a6a7-fc530c1563b5"), new Guid("86000898-3458-4b01-af56-e0eb847e1df7"), new Guid("8eb8ce4c-0bde-4eac-8d3c-e9e60585d211"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("7c5d0e98-5e6d-44ea-8142-40d48eb7c4dc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("062ec03e-b980-40d2-83a2-7fe2e887449e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("63673bd3-4550-43ef-ac3a-812a7ad35ce9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a7bda68d-7372-4d81-a6a7-fc530c1563b5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c9b2113a-0e0e-440a-9291-20f2ab5e61e6"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("30a4c9aa-31cb-4778-b689-d06f5861e29d"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("677a3bef-de3a-4793-a29e-11c8c67558be"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("86000898-3458-4b01-af56-e0eb847e1df7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f1c15e2c-d7e1-4749-93de-f5dfc70c8683"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("38d061fc-cb18-4cc4-95d3-4e3bd808dd6d"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("3ddbecc2-7aca-41b5-8546-12beb52b558d"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("8eb8ce4c-0bde-4eac-8d3c-e9e60585d211"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("f943cdf3-03ef-41fc-8132-6a6809089ecd"));

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
    }
}
