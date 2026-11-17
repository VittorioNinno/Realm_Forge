using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContentForks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Traits",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Subspecies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Subclasses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Spells",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Species",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "RuleModules",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "RuleEntries",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Monsters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "MagicItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Feats",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Equipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "ClassFeatures",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Classes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ForkedFromId",
                table: "Backgrounds",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Traits");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Subspecies");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Subclasses");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "RuleModules");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "RuleEntries");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "MagicItems");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "ClassFeatures");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ForkedFromId",
                table: "Backgrounds");
        }
    }
}
