using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerAIO.Migrations
{
    public partial class changedatatableforshoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StyleCode",
                table: "Shoes",
                newName: "Style");

            migrationBuilder.RenameColumn(
                name: "ShoeName",
                table: "Shoes",
                newName: "Shoe");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "Shoes",
                newName: "Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Style",
                table: "Shoes",
                newName: "StyleCode");

            migrationBuilder.RenameColumn(
                name: "Shoe",
                table: "Shoes",
                newName: "ShoeName");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Shoes",
                newName: "ColorCode");
        }
    }
}