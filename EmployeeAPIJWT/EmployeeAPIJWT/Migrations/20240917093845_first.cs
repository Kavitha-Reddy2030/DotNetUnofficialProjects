using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPIJWT.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("3555589e-0f30-44de-a1e7-64fb8633afbc"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("d2d121a5-cebc-499e-bf5f-58281258211b"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
