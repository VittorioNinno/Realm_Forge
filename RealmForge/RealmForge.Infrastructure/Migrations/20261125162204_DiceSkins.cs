using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DiceSkins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiceUnlockCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Skin = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiceUnlockCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDiceSkins",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Skin = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UnlockedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiceSkins", x => new { x.UserId, x.Skin });
                });

            migrationBuilder.InsertData(
                table: "DiceUnlockCodes",
                columns: new[] { "Id", "Active", "CodeHash", "CreatedAt", "Skin" },
                values: new object[,]
                {
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a01"), true, "a28ce0368d56879f4c34b360c91e37a134f68e4ba0535db46e096f0cb5ca5114", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ember" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a02"), true, "ff4019dd8bc1b49e62ab6719d8b52109105664591d0b2034bd1f788ba34416c8", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "stardust" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiceUnlockCodes_CodeHash",
                table: "DiceUnlockCodes",
                column: "CodeHash",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiceUnlockCodes");

            migrationBuilder.DropTable(
                name: "UserDiceSkins");
        }
    }
}
