using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerAIO.Migrations
{
    public partial class sizedatatypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Sneaker",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Size",
                table: "Sneaker",
                type: "decimal(3,1)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}