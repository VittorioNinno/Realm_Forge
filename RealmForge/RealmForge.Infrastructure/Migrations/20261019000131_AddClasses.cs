using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HitDie = table.Column<int>(type: "integer", nullable: false),
                    PrimaryAbilities = table.Column<int[]>(type: "integer[]", nullable: false),
                    SavingThrows = table.Column<int[]>(type: "integer[]", nullable: false),
                    SkillChoiceCount = table.Column<int>(type: "integer", nullable: false),
                    SkillOptions = table.Column<int[]>(type: "integer[]", nullable: false),
                    CasterProgression = table.Column<int>(type: "integer", nullable: false),
                    SpellcastingAbility = table.Column<int>(type: "integer", nullable: true),
                    SubclassLevel = table.Column<int>(type: "integer", nullable: false),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.CheckConstraint("CK_Classes_HitDie", "\"HitDie\" IN (6, 8, 10, 12)");
                    table.CheckConstraint("CK_Classes_SubclassLevel", "\"SubclassLevel\" BETWEEN 1 AND 20");
                });

            migrationBuilder.CreateTable(
                name: "ClassTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SubclassTitle = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ArmorProficiencies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    WeaponProficiencies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ToolProficiencies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StartingEquipment = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    ProgressionTable = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassTranslations_Classes_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subclasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    CasterProgression = table.Column<int>(type: "integer", nullable: false),
                    SpellcastingAbility = table.Column<int>(type: "integer", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subclasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subclasses_Classes_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CharacterClassId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubclassId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeatures", x => x.Id);
                    table.CheckConstraint("CK_ClassFeatures_Level", "\"Level\" BETWEEN 1 AND 20");
                    table.CheckConstraint("CK_ClassFeatures_Owner", "(\"CharacterClassId\" IS NULL) <> (\"SubclassId\" IS NULL)");
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Classes_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Subclasses_SubclassId",
                        column: x => x.SubclassId,
                        principalTable: "Subclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubclassTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubclassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubclassTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubclassTranslations_Subclasses_SubclassId",
                        column: x => x.SubclassId,
                        principalTable: "Subclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeatureTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassFeatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeatureTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassFeatureTranslations_ClassFeatures_ClassFeatureId",
                        column: x => x.ClassFeatureId,
                        principalTable: "ClassFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_CharacterClassId",
                table: "ClassFeatures",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_SubclassId",
                table: "ClassFeatures",
                column: "SubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatureTranslations_ClassFeatureId_Language",
                table: "ClassFeatureTranslations",
                columns: new[] { "ClassFeatureId", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassTranslations_CharacterClassId_Language",
                table: "ClassTranslations",
                columns: new[] { "CharacterClassId", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subclasses_CharacterClassId",
                table: "Subclasses",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubclassTranslations_SubclassId_Language",
                table: "SubclassTranslations",
                columns: new[] { "SubclassId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassFeatureTranslations");

            migrationBuilder.DropTable(
                name: "ClassTranslations");

            migrationBuilder.DropTable(
                name: "SubclassTranslations");

            migrationBuilder.DropTable(
                name: "ClassFeatures");

            migrationBuilder.DropTable(
                name: "Subclasses");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
