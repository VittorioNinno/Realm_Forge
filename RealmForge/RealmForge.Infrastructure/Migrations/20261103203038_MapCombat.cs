using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapCombat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CombatantId",
                table: "CampaignTokens",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Conditions",
                table: "CampaignTokens",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "EncounterId",
                table: "CampaignMaps",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CombatantId",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "Conditions",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "EncounterId",
                table: "CampaignMaps");
        }
    }
}
