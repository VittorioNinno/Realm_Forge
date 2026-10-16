using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContentVisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Traits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Subspecies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Species",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Feats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Backgrounds",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Traits");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Subspecies");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Feats");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Backgrounds");
        }
    }
}
