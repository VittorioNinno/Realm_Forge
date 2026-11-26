using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShopPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NpcId",
                table: "CampaignShops",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomPrice",
                table: "CampaignShopItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "CampaignShopItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NpcId",
                table: "CampaignShops");

            migrationBuilder.DropColumn(
                name: "CustomPrice",
                table: "CampaignShopItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CampaignShopItems");
        }
    }
}
