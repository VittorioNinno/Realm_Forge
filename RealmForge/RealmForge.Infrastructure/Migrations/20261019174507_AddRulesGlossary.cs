using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRulesGlossary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    RelatedKeys = table.Column<List<string>>(type: "text[]", nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleEntryTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RuleEntryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Aliases = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleEntryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleEntryTranslations_RuleEntries_RuleEntryId",
                        column: x => x.RuleEntryId,
                        principalTable: "RuleEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleEntries_Ruleset_Key",
                table: "RuleEntries",
                columns: new[] { "Ruleset", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RuleEntryTranslations_RuleEntryId_Language",
                table: "RuleEntryTranslations",
                columns: new[] { "RuleEntryId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleEntryTranslations");

            migrationBuilder.DropTable(
                name: "RuleEntries");
        }
    }
}
