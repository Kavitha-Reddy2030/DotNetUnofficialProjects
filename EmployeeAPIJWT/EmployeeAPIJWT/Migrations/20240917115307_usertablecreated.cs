using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPIJWT.Migrations
{
    public partial class usertablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3555589e-0f30-44de-a1e7-64fb8633afbc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d2d121a5-cebc-499e-bf5f-58281258211b"));

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
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("9c01682c-d79a-4612-960c-2f7bf823c7f3"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("af2dd177-6a8e-416e-bbba-9c89fa3e66f7"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9c01682c-d79a-4612-960c-2f7bf823c7f3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("af2dd177-6a8e-416e-bbba-9c89fa3e66f7"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("3555589e-0f30-44de-a1e7-64fb8633afbc"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("d2d121a5-cebc-499e-bf5f-58281258211b"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 });
        }
    }
}
