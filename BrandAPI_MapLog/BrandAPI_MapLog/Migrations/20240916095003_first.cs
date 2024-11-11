using Microsoft.EntityFrameworkCore.Migrations;

namespace BrandAPI_MapLog.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Model", "Name" },
                values: new object[] { 1, "Camry", "Toyota" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Model", "Name" },
                values: new object[] { 2, "Mustang", "Ford" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Model", "Name" },
                values: new object[] { 3, "Model S", "Tesla" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
