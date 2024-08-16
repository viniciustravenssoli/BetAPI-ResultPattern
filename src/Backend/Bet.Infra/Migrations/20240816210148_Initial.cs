using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamAId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamBId = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountOnTeamA = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountOnTeamB = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Odd = table.Column<decimal>(type: "TEXT", nullable: false),
                    BetDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AmountOnTeamA", "AmountOnTeamB", "TeamAId", "TeamBId" },
                values: new object[,]
                {
                    { 1, 100.0m, 150.0m, 1, 2 },
                    { 2, 200.0m, 100.0m, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Team A" },
                    { 2, "Team B" },
                    { 3, "Team C" },
                    { 4, "Team D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_MatchId",
                table: "Bets",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
