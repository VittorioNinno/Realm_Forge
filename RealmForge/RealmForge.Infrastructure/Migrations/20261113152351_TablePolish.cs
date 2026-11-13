using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablePolish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "CampaignTokens",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SheetCharacterId",
                table: "CampaignTokens",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowHp",
                table: "CampaignTokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PlayersLocked",
                table: "CampaignMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "SheetCharacterId",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "ShowHp",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "PlayersLocked",
                table: "CampaignMaps");
        }
    }
}
