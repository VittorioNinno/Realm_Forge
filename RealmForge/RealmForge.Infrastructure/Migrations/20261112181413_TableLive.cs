using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableLive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TableOpenedAt",
                table: "Campaigns",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableOpenedById",
                table: "Campaigns",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableOpenedAt",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "TableOpenedById",
                table: "Campaigns");
        }
    }
}
