using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAPIException.Migrations
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
                values: new object[] { new Guid("38dec2ee-1518-4e24-b0a9-89daa1146b64"), "john.doe@example.com", "1234567890", "John Doe", "password123", 50000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "MobileNumber", "Name", "Password", "Salary" },
                values: new object[] { new Guid("385cd245-7530-4d45-840c-c7b1450e2c77"), "jane.smith@example.com", "0987654321", "Jane Smith", "password123", 60000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
