using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PlayersInteract",
                table: "CampaignTokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PropState",
                table: "CampaignTokens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropType",
                table: "CampaignTokens",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayersInteract",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "PropState",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "PropType",
                table: "CampaignTokens");
        }
    }
}
