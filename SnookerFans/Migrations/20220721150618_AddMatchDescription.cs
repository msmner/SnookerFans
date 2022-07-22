using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnookerFans.Migrations
{
    public partial class AddMatchDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Matches",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Matches");
        }
    }
}
