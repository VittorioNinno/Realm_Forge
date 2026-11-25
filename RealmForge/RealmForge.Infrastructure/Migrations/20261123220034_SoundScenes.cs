using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SoundScenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoundLayers",
                table: "Campaigns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoundSceneId",
                table: "Campaigns",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampaignSoundScenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: true),
                    Layers = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CueId = table.Column<Guid>(type: "uuid", nullable: true),
                    MapId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSoundScenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignSoundScenes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSoundScenes_CampaignId",
                table: "CampaignSoundScenes",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignSoundScenes");

            migrationBuilder.DropColumn(
                name: "SoundLayers",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SoundSceneId",
                table: "Campaigns");
        }
    }
}
