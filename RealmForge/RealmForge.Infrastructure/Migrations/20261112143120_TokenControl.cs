using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TokenControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "ControlledBy",
                table: "CampaignTokens",
                type: "text[]",
                nullable: false,
                defaultValueSql: "'{}'");

            migrationBuilder.AddColumn<int>(
                name: "Hp",
                table: "CampaignTokens",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHp",
                table: "CampaignTokens",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlledBy",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "Hp",
                table: "CampaignTokens");

            migrationBuilder.DropColumn(
                name: "MaxHp",
                table: "CampaignTokens");
        }
    }
}
