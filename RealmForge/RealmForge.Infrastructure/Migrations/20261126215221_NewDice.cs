using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiceUnlockCodes",
                columns: new[] { "Id", "Active", "CodeHash", "CreatedAt", "Skin" },
                values: new object[,]
                {
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a11"), true, "778c22fa2b2fb2daae0114258560acee94bde24669889b7f8e04699d998310a6", new DateTimeOffset(new DateTime(2026, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "dawn" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a12"), true, "ce2b1612776d08650a3dc05f21bd4334640f91bbe175b69dc9cd0f995c969c69", new DateTimeOffset(new DateTime(2026, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "tide" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a11"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a12"));
        }
    }
}
