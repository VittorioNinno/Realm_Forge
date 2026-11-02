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
                name: "Appearance",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coins",
                table: "MonsterTranslations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "MonsterTranslations",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "MonsterTranslations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gear",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Leverage",
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
                name: "Reaction",
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

            migrationBuilder.AddColumn<int>(
                name: "SocialDc",
                table: "Monsters",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appearance",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Coins",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Gear",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Leverage",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Tactics",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Attitude",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SocialDc",
                table: "Monsters");
        }
    }
}
