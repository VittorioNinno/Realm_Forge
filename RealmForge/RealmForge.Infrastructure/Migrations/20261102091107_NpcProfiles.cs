using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NpcProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ancestry",
                table: "MonsterTranslations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Personality",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MonsterTranslations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Secrets",
                table: "MonsterTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Archetype",
                table: "Monsters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Portrait",
                table: "Monsters",
                type: "character varying(200000)",
                maxLength: 200000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ancestry",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Personality",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Secrets",
                table: "MonsterTranslations");

            migrationBuilder.DropColumn(
                name: "Archetype",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Portrait",
                table: "Monsters");
        }
    }
}
