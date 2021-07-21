using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerAIO.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes");

            migrationBuilder.RenameTable(
                name: "Shoes",
                newName: "Sneaker");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Sneaker",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shoe",
                table: "Sneaker",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Sneaker",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Sneaker",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sneaker",
                table: "Sneaker",
                column: "ShoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sneaker",
                table: "Sneaker");

            migrationBuilder.RenameTable(
                name: "Sneaker",
                newName: "Shoes");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Shoes",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Shoe",
                table: "Shoes",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "Shoes",
                type: "nvarchar(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Shoes",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes",
                column: "ShoeId");
        }
    }
}