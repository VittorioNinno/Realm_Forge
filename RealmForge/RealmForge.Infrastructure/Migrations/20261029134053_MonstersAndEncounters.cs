using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MonstersAndEncounters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignEncounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Round = table.Column<int>(type: "integer", nullable: false),
                    CurrentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Shown = table.Column<bool>(type: "boolean", nullable: false),
                    Combatants = table.Column<string>(type: "jsonb", nullable: false),
                    PartyIds = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignEncounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignEncounters_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    HitDice = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Speed = table.Column<int>(type: "integer", nullable: false),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    ChallengeRating = table.Column<decimal>(type: "numeric(6,3)", precision: 6, scale: 3, nullable: false),
                    Xp = table.Column<int>(type: "integer", nullable: false),
                    ProficiencyBonus = table.Column<int>(type: "integer", nullable: false),
                    PassivePerception = table.Column<int>(type: "integer", nullable: false),
                    VariantOfId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Monsters_VariantOfId",
                        column: x => x.VariantOfId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MonsterTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Alias = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Subtitle = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ArmorClass = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Speed = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    SavingThrows = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Skills = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DamageVulnerabilities = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DamageResistances = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DamageImmunities = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ConditionImmunities = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Senses = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Languages = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Traits = table.Column<string>(type: "text", nullable: false),
                    Actions = table.Column<string>(type: "text", nullable: false),
                    BonusActions = table.Column<string>(type: "text", nullable: false),
                    Reactions = table.Column<string>(type: "text", nullable: false),
                    LegendaryActions = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterTranslations_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEncounters_CampaignId",
                table: "CampaignEncounters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_AuthorId",
                table: "Monsters",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_Ruleset_Type",
                table: "Monsters",
                columns: new[] { "Ruleset", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_VariantOfId",
                table: "Monsters",
                column: "VariantOfId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterTranslations_MonsterId_Language",
                table: "MonsterTranslations",
                columns: new[] { "MonsterId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignEncounters");

            migrationBuilder.DropTable(
                name: "MonsterTranslations");

            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
