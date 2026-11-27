using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealmForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Achievements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiceUnlockCodes");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "CampaignMaps",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            // The maps made before the creator was kept: the work of whoever created their campaign
            migrationBuilder.Sql("UPDATE \"CampaignMaps\" AS m SET \"CreatedById\" = c.\"CreatedById\" FROM \"Campaigns\" AS c WHERE m.\"CampaignId\" = c.\"Id\" AND m.\"CreatedById\" = '';");

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Key = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    EarnedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    GrantedById = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    RevokedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RevokedById = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: true),
                    Seen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => new { x.UserId, x.Key });
                });

            migrationBuilder.CreateTable(
                name: "UserDiceStats",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    Rolls = table.Column<int>(type: "integer", nullable: false),
                    NaturalTwenties = table.Column<int>(type: "integer", nullable: false),
                    NaturalOnes = table.Column<int>(type: "integer", nullable: false),
                    LastD20 = table.Column<int>(type: "integer", nullable: true),
                    LastTwentyCampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastTwentyAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    OneThenTwenty = table.Column<bool>(type: "boolean", nullable: false),
                    TwoTwentiesInASitting = table.Column<bool>(type: "boolean", nullable: false),
                    TwentyAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TimeZone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiceStats", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "UserDiceStats");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CampaignMaps");

            migrationBuilder.CreateTable(
                name: "DiceUnlockCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CodeHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Skin = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiceUnlockCodes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiceUnlockCodes",
                columns: new[] { "Id", "Active", "CodeHash", "CreatedAt", "Skin" },
                values: new object[,]
                {
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a01"), true, "a28ce0368d56879f4c34b360c91e37a134f68e4ba0535db46e096f0cb5ca5114", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ember" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a02"), true, "ff4019dd8bc1b49e62ab6719d8b52109105664591d0b2034bd1f788ba34416c8", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "stardust" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a03"), true, "7fbf34eac4cf85991976e8cab983dc8760f80b8ea92a259571b7a15a87dad0fd", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "frost" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a04"), true, "2580a02cc213cf4fe7ebbbc4374ca5f192ebd1c336084a00664d34fcb624bbdf", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "storm" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a05"), true, "1b801a85ac134526dd937a8dec243b2027524f82775cfaefe98f4e3dad45aa86", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "bone" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a06"), true, "5e3ca5ae245f876deeb0bf58678e27f51b680432ae419ee96ad26d27cfb0a7c5", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "hoard" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a07"), true, "5312237321c05bc4201381dfa48a16b1c9dfa3f3299f6e8103b3045e0ed48c9b", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "abyss" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a08"), true, "4e11d9bcc3e7cb761de86485adcbb1456d750fbdd5b9dca827ba1900a587dffe", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "fey" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a09"), true, "697e4badb1e78b3a0aad3a02255323f76fb3f0b41ba2b6146baddf31e36645f4", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "acid" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a10"), true, "011f3e18b8e239d3ba42e698c02c772cd808690fd972e68461b9d401b3e6da24", new DateTimeOffset(new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "arcane" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a11"), true, "778c22fa2b2fb2daae0114258560acee94bde24669889b7f8e04699d998310a6", new DateTimeOffset(new DateTime(2026, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "dawn" },
                    { new Guid("6f1c2a5e-4d1b-4c7e-9a2f-1b9e7c3d5a12"), true, "ce2b1612776d08650a3dc05f21bd4334640f91bbe175b69dc9cd0f995c969c69", new DateTimeOffset(new DateTime(2026, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "tide" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiceUnlockCodes_CodeHash",
                table: "DiceUnlockCodes",
                column: "CodeHash",
                unique: true);
        }
    }
}
