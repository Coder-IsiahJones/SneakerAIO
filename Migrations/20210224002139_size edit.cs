using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerAIO.Migrations
{
    public partial class sizeedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Sneaker",
                type: "decimal(3,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Sneaker",
                type: "decimal(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,1)");
        }
    }
}