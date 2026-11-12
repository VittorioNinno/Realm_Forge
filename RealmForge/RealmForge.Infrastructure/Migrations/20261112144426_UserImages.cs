using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "CampaignTokens",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonsterImageChoices",
                columns: table => new
                {
                    OwnerId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    MonsterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterImageChoices", x => new { x.OwnerId, x.MonsterId });
                    table.ForeignKey(
                        name: "FK_MonsterImageChoices_UserImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "UserImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterImageChoices_ImageId",
                table: "MonsterImageChoices",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_OwnerId",
                table: "UserImages",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterImageChoices");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "CampaignTokens");
        }
    }
}
