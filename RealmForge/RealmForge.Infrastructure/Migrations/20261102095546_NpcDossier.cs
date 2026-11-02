using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NpcDossier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdventureRole",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gear",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MonsterTranslations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tactics",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Attitude",
                table: "Monsters",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdventureRole",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Gear",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Social",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Tactics",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Attitude",
                table: "Monsters");
        }
    }
}
