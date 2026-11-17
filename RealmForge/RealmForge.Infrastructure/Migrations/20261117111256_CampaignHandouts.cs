using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampaignHandouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignHandouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    TitleIt = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    TitleEn = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    BodyIt = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    BodyEn = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    RevealedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignHandouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignHandouts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignHandouts_CampaignId_RevealedAt",
                table: "CampaignHandouts",
                columns: new[] { "CampaignId", "RevealedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignHandouts");
        }
    }
}
