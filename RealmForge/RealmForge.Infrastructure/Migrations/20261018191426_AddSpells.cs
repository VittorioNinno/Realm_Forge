using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSpells : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    School = table.Column<int>(type: "integer", nullable: false),
                    Classes = table.Column<int[]>(type: "integer[]", nullable: false),
                    Ritual = table.Column<bool>(type: "boolean", nullable: false),
                    Concentration = table.Column<bool>(type: "boolean", nullable: false),
                    Verbal = table.Column<bool>(type: "boolean", nullable: false),
                    Somatic = table.Column<bool>(type: "boolean", nullable: false),
                    Material = table.Column<bool>(type: "boolean", nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.CheckConstraint("CK_Spells_Level", "\"Level\" BETWEEN 0 AND 9");
                });

            migrationBuilder.CreateTable(
                name: "SpellTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpellId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HigherLevels = table.Column<string>(type: "text", nullable: true),
                    CastingTime = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Range = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Duration = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MaterialComponent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellTranslations_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Ruleset_Level",
                table: "Spells",
                columns: new[] { "Ruleset", "Level" });

            migrationBuilder.CreateIndex(
                name: "IX_SpellTranslations_SpellId_Language",
                table: "SpellTranslations",
                columns: new[] { "SpellId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellTranslations");

            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
