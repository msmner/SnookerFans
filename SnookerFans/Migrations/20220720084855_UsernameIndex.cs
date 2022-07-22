using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnookerFans.Migrations
{
    public partial class UsernameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Players",
                newName: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserName",
                table: "Players",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_UserName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Players",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
