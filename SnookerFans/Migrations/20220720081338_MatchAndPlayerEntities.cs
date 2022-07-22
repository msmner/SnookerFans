using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnookerFans.Migrations
{
    public partial class MatchAndPlayerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    LifeTimeMaximums = table.Column<int>(type: "integer", nullable: false),
                    CenturyBreaks = table.Column<int>(type: "integer", nullable: false),
                    HalfCenturyBreaks = table.Column<int>(type: "integer", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<string>(type: "text", nullable: false),
                    PlayerOneId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerTwoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CenturyBreaks = table.Column<int>(type: "integer", nullable: false),
                    HalfCenturyBreaks = table.Column<int>(type: "integer", nullable: false),
                    PlayerOneMaximums = table.Column<int>(type: "integer", nullable: false),
                    PlayerTwoMaximums = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Players_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
