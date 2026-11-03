using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MapFogPingFocus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FocusAt",
                table: "CampaignMaps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FocusX",
                table: "CampaignMaps",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FocusY",
                table: "CampaignMaps",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FocusZoom",
                table: "CampaignMaps",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<List<double>>(
                name: "Fog",
                table: "CampaignMaps",
                type: "double precision[]",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "FogEnabled",
                table: "CampaignMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "PingAt",
                table: "CampaignMaps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PingColor",
                table: "CampaignMaps",
                type: "character varying(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PingX",
                table: "CampaignMaps",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PingY",
                table: "CampaignMaps",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FocusAt",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "FocusX",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "FocusY",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "FocusZoom",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "Fog",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "FogEnabled",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "PingAt",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "PingColor",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "PingX",
                table: "CampaignMaps");

            migrationBuilder.DropColumn(
                name: "PingY",
                table: "CampaignMaps");
        }
    }
}
