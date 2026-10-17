using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StructuredFeatPrerequisites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeatTranslations_FeatId",
                table: "FeatTranslations");

            migrationBuilder.AddColumn<string>(
                name: "PrerequisiteNote",
                table: "FeatTranslations",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            //  Preserve free-text prerequisites typed by users: Homebrew feats keep them as a note
            //  in every translation. SRD feats are re-synchronized by FeatSeeder at startup.
            migrationBuilder.Sql("""
                UPDATE "FeatTranslations" AS t
                SET "PrerequisiteNote" = LEFT(f."Prerequisite", 300)
                FROM "Feats" AS f
                WHERE t."FeatId" = f."Id"
                  AND f."IsOfficialSRD" = FALSE
                  AND f."Prerequisite" IS NOT NULL
                  AND f."Prerequisite" <> '';
                """);

            //  Remove duplicated translations (same feat and language) before creating the unique index
            migrationBuilder.Sql("""
                DELETE FROM "FeatTranslations" AS a
                USING "FeatTranslations" AS b
                WHERE a."FeatId" = b."FeatId"
                  AND a."Language" = b."Language"
                  AND a."Id" > b."Id";
                """);

            migrationBuilder.DropColumn(
                name: "Prerequisite",
                table: "Feats");

            migrationBuilder.AddColumn<int[]>(
                name: "PrerequisiteAbilities",
                table: "Feats",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<int>(
                name: "PrerequisiteFeature",
                table: "Feats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrerequisiteMinimumLevel",
                table: "Feats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrerequisiteMinimumScore",
                table: "Feats",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatTranslations_FeatId_Language",
                table: "FeatTranslations",
                columns: new[] { "FeatId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FeatTranslations_FeatId_Language",
                table: "FeatTranslations");

            migrationBuilder.DropColumn(
                name: "PrerequisiteNote",
                table: "FeatTranslations");

            migrationBuilder.DropColumn(
                name: "PrerequisiteAbilities",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "PrerequisiteFeature",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "PrerequisiteMinimumLevel",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "PrerequisiteMinimumScore",
                table: "Feats");

            migrationBuilder.AddColumn<string>(
                name: "Prerequisite",
                table: "Feats",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatTranslations_FeatId",
                table: "FeatTranslations",
                column: "FeatId");
        }
    }
}
