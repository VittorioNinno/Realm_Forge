using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampaignNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedNickname",
                table: "AspNetUsers",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampaignNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Body = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignNotes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NormalizedNickname",
                table: "AspNetUsers",
                column: "NormalizedNickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignNotes_CampaignId_Kind",
                table: "CampaignNotes",
                columns: new[] { "CampaignId", "Kind" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignNotes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NormalizedNickname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedNickname",
                table: "AspNetUsers");
        }
    }
}
