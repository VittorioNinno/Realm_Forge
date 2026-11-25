using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecretDice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiceUnlockCodes",
                columns: new[] { "Id", "Active", "CodeHash", "CreatedAt", "Skin" },
                values: new object[,]
                {
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a03"), true, "7fbf34eac4cf85991976e8cab983dc8760f80b8ea92a259571b7a15a87dad0fd", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "frost" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a04"), true, "2580a02cc213cf4fe7ebbbc4374ca5f192ebd1c336084a00664d34fcb624bbdf", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "storm" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a05"), true, "1b801a85ac134526dd937a8dec243b2027524f82775cfaefe98f4e3dad45aa86", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "bone" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a06"), true, "5e3ca5ae245f876deeb0bf58678e27f51b680432ae419ee96ad26d27cfb0a7c5", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "hoard" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a07"), true, "5312237321c05bc4201381dfa48a16b1c9dfa3f3299f6e8103b3045e0ed48c9b", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "abyss" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a08"), true, "4e11d9bcc3e7cb761de86485adcbb1456d750fbdd5b9dca827ba1900a587dffe", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "fey" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a09"), true, "697e4badb1e78b3a0aad3a02255323f76fb3f0b41ba2b6146baddf31e36645f4", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "acid" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a10"), true, "011f3e18b8e239d3ba42e698c02c772cd808690fd972e68461b9d401b3e6da24", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "arcane" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a03"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a04"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a05"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a06"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a07"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a08"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a09"));

            migrationBuilder.DeleteData(
                table: "DiceUnlockCodes",
                keyColumn: "Id",
                keyValue: new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a10"));
        }
    }
}
