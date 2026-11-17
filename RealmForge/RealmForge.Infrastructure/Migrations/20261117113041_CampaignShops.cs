using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampaignShops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignShops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    NameIt = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    DescriptionIt = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    DescriptionEn = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    PricePercent = table.Column<int>(type: "integer", nullable: false),
                    Open = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignShops_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignShopItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShopId = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    MagicItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    PriceInCopper = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignShopItems_CampaignShops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "CampaignShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignShopItems_ShopId",
                table: "CampaignShopItems",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignShops_CampaignId",
                table: "CampaignShops",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignShopItems");

            migrationBuilder.DropTable(
                name: "CampaignShops");
        }
    }
}
