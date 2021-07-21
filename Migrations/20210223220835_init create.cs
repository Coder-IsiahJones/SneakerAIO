using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SneakerAIO.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.ShoeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoes");
        }
    }
}