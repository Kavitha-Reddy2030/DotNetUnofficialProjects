using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class authorizationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("7937cb2a-fb69-4903-869e-5d912588a70e"), "Bio of New Author 1.", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 1", "https://example.com/images/new_author_1.jpg" },
                    { new Guid("1adc85e9-0f4c-4d30-a932-66ff804a192e"), "Bio of New Author 2.", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 2", "https://example.com/images/new_author_2.jpg" },
                    { new Guid("0525fcfb-dffb-401b-9d13-da22d9278558"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("8b6ec3e9-e872-469a-8123-8cae070def93"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("d2c35f24-4ac8-42f4-9842-e8e5fff7bbc6"), "Extra Small" },
                    { new Guid("a831598b-6041-4f5d-acfe-e41e4ac8bc37"), "Extra Large" },
                    { new Guid("85b8d099-09ac-485b-9984-55aeb9284bb9"), "Small" },
                    { new Guid("a77f3206-c361-4b52-a3c7-9dba2253b9a2"), "Medium" },
                    { new Guid("1fa3e269-98f4-4d9b-a7d7-cbf0760d378b"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("a937aabe-1a08-4815-b64d-bba9d2ce6f7b"), "adminpass", "Admin", "admin" },
                    { new Guid("806d4961-9d7a-41c0-9e58-86033436ae18"), "userpass", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4c906155-1b56-421c-bcac-f79ff6262cd8"), new Guid("7937cb2a-fb69-4903-869e-5d912588a70e"), new Guid("d2c35f24-4ac8-42f4-9842-e8e5fff7bbc6"), "https://example.com/images/new_book_1.jpg", "Description for New Book 1.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 1" },
                    { new Guid("5a731842-30d3-4e49-bc0b-9ffba5a98dc4"), new Guid("1adc85e9-0f4c-4d30-a932-66ff804a192e"), new Guid("a831598b-6041-4f5d-acfe-e41e4ac8bc37"), "https://example.com/images/new_book_2.jpg", "Description for New Book 2.", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 2" },
                    { new Guid("e059fd04-b67d-4471-822a-2aa161f24e25"), new Guid("0525fcfb-dffb-401b-9d13-da22d9278558"), new Guid("a77f3206-c361-4b52-a3c7-9dba2253b9a2"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("3e85e9dc-b567-4527-b85f-7cdb63ed1001"), new Guid("8b6ec3e9-e872-469a-8123-8cae070def93"), new Guid("1fa3e269-98f4-4d9b-a7d7-cbf0760d378b"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("85b8d099-09ac-485b-9984-55aeb9284bb9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3e85e9dc-b567-4527-b85f-7cdb63ed1001"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4c906155-1b56-421c-bcac-f79ff6262cd8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5a731842-30d3-4e49-bc0b-9ffba5a98dc4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e059fd04-b67d-4471-822a-2aa161f24e25"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("806d4961-9d7a-41c0-9e58-86033436ae18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a937aabe-1a08-4815-b64d-bba9d2ce6f7b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("0525fcfb-dffb-401b-9d13-da22d9278558"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1adc85e9-0f4c-4d30-a932-66ff804a192e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("7937cb2a-fb69-4903-869e-5d912588a70e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8b6ec3e9-e872-469a-8123-8cae070def93"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("1fa3e269-98f4-4d9b-a7d7-cbf0760d378b"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("a77f3206-c361-4b52-a3c7-9dba2253b9a2"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("a831598b-6041-4f5d-acfe-e41e4ac8bc37"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("d2c35f24-4ac8-42f4-9842-e8e5fff7bbc6"));

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
    }
}
