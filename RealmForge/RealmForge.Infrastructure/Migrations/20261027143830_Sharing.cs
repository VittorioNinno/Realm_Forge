using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sharing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterShares_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    GrantedById = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentShares", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterShares_CharacterId_UserId",
                table: "CharacterShares",
                columns: new[] { "CharacterId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterShares_UserId",
                table: "CharacterShares",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentShares_EntityId_UserId",
                table: "ContentShares",
                columns: new[] { "EntityId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentShares_UserId",
                table: "ContentShares",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterShares");

            migrationBuilder.DropTable(
                name: "ContentShares");
        }
    }
}
