using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapTerrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "Terrain",
                table: "CampaignMaps",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "TerrainBlocks",
                table: "CampaignMaps",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Terrain",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "TerrainBlocks",
                table: "CampaignMaps");
        }
    }
}
