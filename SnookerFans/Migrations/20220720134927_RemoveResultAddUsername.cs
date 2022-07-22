using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnookerFans.Migrations
{
    public partial class RemoveResultAddUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Matches",
                newName: "PlayerTwoHalfCenturyBreaks");

            migrationBuilder.RenameColumn(
                name: "HalfCenturyBreaks",
                table: "Matches",
                newName: "PlayerTwoCenturyBreaks");

            migrationBuilder.RenameColumn(
                name: "CenturyBreaks",
                table: "Matches",
                newName: "PlayerOneHalfCenturyBreaks");

            migrationBuilder.AddColumn<int>(
                name: "PlayerOneCenturyBreaks",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerOneCenturyBreaks",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoHalfCenturyBreaks",
                table: "Matches",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoCenturyBreaks",
                table: "Matches",
                newName: "HalfCenturyBreaks");

            migrationBuilder.RenameColumn(
                name: "PlayerOneHalfCenturyBreaks",
                table: "Matches",
                newName: "CenturyBreaks");
        }
    }
}
