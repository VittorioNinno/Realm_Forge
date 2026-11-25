using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HandoutPuzzles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PuzzleAnswer",
                table: "CampaignHandouts",
                type: "character varying(240)",
                maxLength: 240,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PuzzleDoorId",
                table: "CampaignHandouts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SolvedAt",
                table: "CampaignHandouts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolvedBy",
                table: "CampaignHandouts",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuzzleAnswer",
                table: "CampaignHandouts");

            migrationBuilder.DropColumn(
                name: "PuzzleDoorId",
                table: "CampaignHandouts");

            migrationBuilder.DropColumn(
                name: "SolvedAt",
                table: "CampaignHandouts");

            migrationBuilder.DropColumn(
                name: "SolvedBy",
                table: "CampaignHandouts");
        }
    }
}
