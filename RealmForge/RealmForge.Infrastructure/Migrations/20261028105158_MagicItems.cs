using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MagicItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagicItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: true),
                    RequiresAttunement = table.Column<bool>(type: "boolean", nullable: false),
                    Mechanics = table.Column<string>(type: "jsonb", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicItems_MagicItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MagicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagicItemTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MagicItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subtitle = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItemTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicItemTranslations_MagicItems_MagicItemId",
                        column: x => x.MagicItemId,
                        principalTable: "MagicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MagicItems_ParentId",
                table: "MagicItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicItems_Ruleset_Type",
                table: "MagicItems",
                columns: new[] { "Ruleset", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_MagicItemTranslations_MagicItemId_Language",
                table: "MagicItemTranslations",
                columns: new[] { "MagicItemId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MagicItemTranslations");

            migrationBuilder.DropTable(
                name: "MagicItems");
        }
    }
}
