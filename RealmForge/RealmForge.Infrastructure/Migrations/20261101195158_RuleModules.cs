using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RuleModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Effects = table.Column<string>(type: "jsonb", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleModuleTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RuleModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleModuleTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleModuleTranslations_RuleModules_RuleModuleId",
                        column: x => x.RuleModuleId,
                        principalTable: "RuleModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleModules_AuthorId",
                table: "RuleModules",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleModuleTranslations_RuleModuleId_Language",
                table: "RuleModuleTranslations",
                columns: new[] { "RuleModuleId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleModuleTranslations");

            migrationBuilder.DropTable(
                name: "RuleModules");
        }
    }
}
