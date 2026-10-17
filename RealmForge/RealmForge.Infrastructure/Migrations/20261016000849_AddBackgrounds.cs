using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBackgrounds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AbilityOptions = table.Column<int[]>(type: "integer[]", nullable: false),
                    SkillProficiencies = table.Column<int[]>(type: "integer[]", nullable: false),
                    OriginFeatId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Backgrounds_Feats_OriginFeatId",
                        column: x => x.OriginFeatId,
                        principalTable: "Feats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BackgroundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ToolProficiencies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Languages = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Equipment = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    OriginFeatNote = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    FeatureName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    FeatureDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackgroundTranslations_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backgrounds_OriginFeatId",
                table: "Backgrounds",
                column: "OriginFeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundTranslations_BackgroundId_Language",
                table: "BackgroundTranslations",
                columns: new[] { "BackgroundId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackgroundTranslations");

            migrationBuilder.DropTable(
                name: "Backgrounds");
        }
    }
}
