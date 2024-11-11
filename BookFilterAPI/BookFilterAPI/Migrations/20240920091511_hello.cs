using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookFilterAPI.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("2b719459-a057-46e8-8390-953b11a6afda"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("14ec2ced-0b14-4c55-8c8e-76c408c326dd"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("827662ca-0989-45cf-b063-3aea16c1acbd"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c47a2160-8c0e-459e-8efe-44de15f1dc07"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c8c52296-051c-4afe-b6b9-d43db1a42781"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("0b8ea859-2a6b-40fa-abb8-ddad2edba051"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3ef4e266-20d0-432e-89ff-ad60c9b5ff78"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c906e0f8-0a71-40f1-b4c7-9f9f3bdd7cf7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("e62092c5-8856-4906-a686-98e5434c7fc8"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("5b78e4b7-c0d7-4840-b985-c0445c38f2d0"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("9872312a-5fc7-4c3d-9ffe-c2def97b2856"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("a056b77e-f6b4-4c85-9948-54fa570f7c24"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("ce3a9bdb-c1b2-4ce1-9313-0a4bd8a7a183"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Birthdate", "Name", "ProfileImageUrl" },
                values: new object[,]
                {
                    { new Guid("430728ca-12b1-424f-850c-26172cddba73"), "Bio of New Author 1.", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 1", "https://example.com/images/new_author_1.jpg" },
                    { new Guid("6d141d6f-f24a-4bdd-90fc-fd03f67fb5ae"), "Bio of New Author 2.", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Author 2", "https://example.com/images/new_author_2.jpg" },
                    { new Guid("67df8576-936e-4028-baa2-621b4411aa5e"), "British author, best known for the Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling", "https://example.com/images/jk_rowling.jpg" },
                    { new Guid("cedafaee-281d-4495-b06e-2fa51bb90561"), "American author, known for the 'A Song of Ice and Fire' series.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin", "https://example.com/images/george_rr_martin.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BookSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { new Guid("9de96b83-eedb-4ee9-beaf-3498f5c38cc0"), "Extra Small" },
                    { new Guid("3038e735-fcbb-4daf-9753-23b040e00870"), "Extra Large" },
                    { new Guid("a5942dfe-ac0d-41c3-af83-04eabce51364"), "Small" },
                    { new Guid("4e2665d0-400c-44da-a3ca-fb874d7fac96"), "Medium" },
                    { new Guid("23dd92c0-f194-45d5-b143-d0227d399d73"), "Large" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookSizeId", "CoverImageUrl", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("79ce6d52-2106-4a0e-b3a0-a31b59faa500"), new Guid("430728ca-12b1-424f-850c-26172cddba73"), new Guid("9de96b83-eedb-4ee9-beaf-3498f5c38cc0"), "https://example.com/images/new_book_1.jpg", "Description for New Book 1.", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 1" },
                    { new Guid("97ac36c3-f3ca-4a8e-9e37-f39a3124fc85"), new Guid("6d141d6f-f24a-4bdd-90fc-fd03f67fb5ae"), new Guid("3038e735-fcbb-4daf-9753-23b040e00870"), "https://example.com/images/new_book_2.jpg", "Description for New Book 2.", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Book 2" },
                    { new Guid("c9c18cf3-132b-40ef-97d6-57a9cdd45364"), new Guid("67df8576-936e-4028-baa2-621b4411aa5e"), new Guid("4e2665d0-400c-44da-a3ca-fb874d7fac96"), "https://example.com/images/harry_potter_1.jpg", "First book in the Harry Potter series.", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { new Guid("aec57b56-d394-4b79-94ef-2e08ecfc288a"), new Guid("cedafaee-281d-4495-b06e-2fa51bb90561"), new Guid("23dd92c0-f194-45d5-b143-d0227d399d73"), "https://example.com/images/game_of_thrones.jpg", "First book in the A Song of Ice and Fire series.", new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("a5942dfe-ac0d-41c3-af83-04eabce51364"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("79ce6d52-2106-4a0e-b3a0-a31b59faa500"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("97ac36c3-f3ca-4a8e-9e37-f39a3124fc85"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("aec57b56-d394-4b79-94ef-2e08ecfc288a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c9c18cf3-132b-40ef-97d6-57a9cdd45364"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("430728ca-12b1-424f-850c-26172cddba73"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("67df8576-936e-4028-baa2-621b4411aa5e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6d141d6f-f24a-4bdd-90fc-fd03f67fb5ae"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("cedafaee-281d-4495-b06e-2fa51bb90561"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("23dd92c0-f194-45d5-b143-d0227d399d73"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("3038e735-fcbb-4daf-9753-23b040e00870"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("4e2665d0-400c-44da-a3ca-fb874d7fac96"));

            migrationBuilder.DeleteData(
                table: "BookSizes",
                keyColumn: "Id",
                keyValue: new Guid("9de96b83-eedb-4ee9-beaf-3498f5c38cc0"));

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
        }
    }
}
