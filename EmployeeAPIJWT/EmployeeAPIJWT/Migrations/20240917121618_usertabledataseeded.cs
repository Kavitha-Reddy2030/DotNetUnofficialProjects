using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPIJWT.Migrations
{
    public partial class usertabledataseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[,]
                {
                    { new Guid("6b126ccd-734f-4705-8979-ba669713b919"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 },
                    { new Guid("f452b741-c1c3-4ede-9e54-73ff1f547e81"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b682994d-68e9-4b3c-ae2c-348bc9e0405e"), "admin123", "Admin", "admin" },
                    { new Guid("d6f7527f-0a25-40c8-8d47-f9d3d1e70b6e"), "user123", "User", "user1" },
                    { new Guid("36451d92-3678-405d-a1b5-43a0b98d3705"), "user234", "User", "user2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6b126ccd-734f-4705-8979-ba669713b919"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("f452b741-c1c3-4ede-9e54-73ff1f547e81"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36451d92-3678-405d-a1b5-43a0b98d3705"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b682994d-68e9-4b3c-ae2c-348bc9e0405e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6f7527f-0a25-40c8-8d47-f9d3d1e70b6e"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("9c01682c-d79a-4612-960c-2f7bf823c7f3"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("af2dd177-6a8e-416e-bbba-9c89fa3e66f7"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 });
        }
    }
}
