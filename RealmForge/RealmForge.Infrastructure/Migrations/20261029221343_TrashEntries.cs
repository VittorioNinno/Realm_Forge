using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrashEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrashEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Kind = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    NameIt = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashEntries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrashEntries_ExpiresAt",
                table: "TrashEntries",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_TrashEntries_UserId_ExpiresAt",
                table: "TrashEntries",
                columns: new[] { "UserId", "ExpiresAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrashEntries");
        }
    }
}
