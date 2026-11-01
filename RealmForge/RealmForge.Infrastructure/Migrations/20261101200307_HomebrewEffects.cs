using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HomebrewEffects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Effects",
                table: "Subspecies",
                type: "jsonb",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Effects",
                table: "Species",
                type: "jsonb",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Effects",
                table: "Feats",
                type: "jsonb",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Effects",
                table: "ClassFeatures",
                type: "jsonb",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effects",
                table: "Subspecies");

            migrationBuilder.DropColumn(
                name: "Effects",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Effects",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "Effects",
                table: "ClassFeatures");
        }
    }
}
