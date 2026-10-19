using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubspeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    BackgroundId = table.Column<Guid>(type: "uuid", nullable: false),
                    Languages = table.Column<List<string>>(type: "text[]", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubclassId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClassSkills = table.Column<int[]>(type: "integer[]", nullable: false),
                    AbilityMethod = table.Column<int>(type: "integer", nullable: false),
                    BaseScores = table.Column<List<int>>(type: "integer[]", nullable: false),
                    BonusMode = table.Column<int>(type: "integer", nullable: false),
                    AbilityBonuses = table.Column<List<int>>(type: "integer[]", nullable: false),
                    BackgroundEquipment = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ClassEquipment = table.Column<List<string>>(type: "text[]", nullable: false),
                    SpellIds = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    MaxHitPoints = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.CheckConstraint("CK_Characters_Level", "\"Level\" BETWEEN 1 AND 20");
                    table.ForeignKey(
                        name: "FK_Characters_Backgrounds_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "Backgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Subclasses_SubclassId",
                        column: x => x.SubclassId,
                        principalTable: "Subclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Subspecies_SubspeciesId",
                        column: x => x.SubspeciesId,
                        principalTable: "Subspecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BackgroundId",
                table: "Characters",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OwnerId",
                table: "Characters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SubclassId",
                table: "Characters",
                column: "SubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SubspeciesId",
                table: "Characters",
                column: "SubspeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
