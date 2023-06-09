using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceScreen.Migrations
{
    public partial class StoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoreLogo",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreLogo",
                table: "Stores");
        }
    }
}
