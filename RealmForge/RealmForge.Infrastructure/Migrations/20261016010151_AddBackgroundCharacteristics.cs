using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBackgroundCharacteristics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Bonds",
                table: "BackgroundTranslations",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CharacteristicsIntro",
                table: "BackgroundTranslations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Flaws",
                table: "BackgroundTranslations",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "Ideals",
                table: "BackgroundTranslations",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "PersonalityTraits",
                table: "BackgroundTranslations",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bonds",
                table: "BackgroundTranslations");

            migrationBuilder.DropColumn(
                name: "CharacteristicsIntro",
                table: "BackgroundTranslations");

            migrationBuilder.DropColumn(
                name: "Flaws",
                table: "BackgroundTranslations");

            migrationBuilder.DropColumn(
                name: "Ideals",
                table: "BackgroundTranslations");

            migrationBuilder.DropColumn(
                name: "PersonalityTraits",
                table: "BackgroundTranslations");
        }
    }
}
