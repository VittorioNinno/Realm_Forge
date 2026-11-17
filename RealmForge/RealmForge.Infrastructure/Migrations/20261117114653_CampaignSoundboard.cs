using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampaignSoundboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SoundCueAt",
                table: "Campaigns",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoundCueId",
                table: "Campaigns",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SoundTrackAt",
                table: "Campaigns",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoundTrackId",
                table: "Campaigns",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampaignSounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Effect = table.Column<bool>(type: "boolean", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignSounds_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSounds_CampaignId",
                table: "CampaignSounds",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignSounds");

            migrationBuilder.DropColumn(
                name: "SoundCueAt",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SoundCueId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SoundTrackAt",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SoundTrackId",
                table: "Campaigns");
        }
    }
}
