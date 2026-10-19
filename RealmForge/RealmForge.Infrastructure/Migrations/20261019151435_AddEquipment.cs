using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CostInCopper = table.Column<int>(type: "integer", nullable: true),
                    WeightInPounds = table.Column<decimal>(type: "numeric(9,3)", precision: 9, scale: 3, nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    WeaponCategory = table.Column<int>(type: "integer", nullable: true),
                    WeaponRange = table.Column<int>(type: "integer", nullable: true),
                    DamageDice = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DamageType = table.Column<int>(type: "integer", nullable: true),
                    VersatileDamageDice = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    WeaponProperties = table.Column<int[]>(type: "integer[]", nullable: false),
                    NormalRange = table.Column<int>(type: "integer", nullable: true),
                    LongRange = table.Column<int>(type: "integer", nullable: true),
                    Mastery = table.Column<int>(type: "integer", nullable: true),
                    ArmorCategory = table.Column<int>(type: "integer", nullable: true),
                    ArmorClass = table.Column<int>(type: "integer", nullable: true),
                    ArmorAddsDexterity = table.Column<bool>(type: "boolean", nullable: false),
                    ArmorMaxDexterityBonus = table.Column<int>(type: "integer", nullable: true),
                    StrengthRequirement = table.Column<int>(type: "integer", nullable: true),
                    StealthDisadvantage = table.Column<bool>(type: "boolean", nullable: false),
                    ToolCategory = table.Column<int>(type: "integer", nullable: true),
                    ToolAbility = table.Column<int>(type: "integer", nullable: true),
                    FocusType = table.Column<int>(type: "integer", nullable: true),
                    SpeedInFeet = table.Column<int>(type: "integer", nullable: true),
                    SpeedInMilesPerHour = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: true),
                    CarryingCapacityInPounds = table.Column<int>(type: "integer", nullable: true),
                    Ruleset = table.Column<int>(type: "integer", nullable: false),
                    IsOfficialSRD = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.CheckConstraint("CK_Equipment_Cost", "\"CostInCopper\" IS NULL OR \"CostInCopper\" >= 0");
                    table.CheckConstraint("CK_Equipment_Quantity", "\"Quantity\" >= 1");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentTranslations_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Ruleset_Category",
                table: "Equipment",
                columns: new[] { "Ruleset", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTranslations_EquipmentId_Language",
                table: "EquipmentTranslations",
                columns: new[] { "EquipmentId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentTranslations");

            migrationBuilder.DropTable(
                name: "Equipment");
        }
    }
}
