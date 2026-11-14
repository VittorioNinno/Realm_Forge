using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapStrike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StrikeAt",
                table: "CampaignMaps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrikeDamage",
                table: "CampaignMaps",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrikeKind",
                table: "CampaignMaps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StrikeTokenId",
                table: "CampaignMaps",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrikeAt",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "StrikeDamage",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "StrikeKind",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "StrikeTokenId",
                table: "CampaignMaps");
        }
    }
}
