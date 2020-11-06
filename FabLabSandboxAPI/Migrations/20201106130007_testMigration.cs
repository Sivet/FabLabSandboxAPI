using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class testMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakerSpaceCity",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "MakerSpacePostCode",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "MakerSpaceStreet",
                table: "MakerSpaces");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "MakerSpaces",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MakerSpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_MakerSpaces_MakerSpaceId",
                        column: x => x.MakerSpaceId,
                        principalTable: "MakerSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    BadgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.BadgeId);
                    table.ForeignKey(
                        name: "FK_Badges_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventGivesBadges",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    BadgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventGivesBadges", x => new { x.EventId, x.BadgeId });
                    table.ForeignKey(
                        name: "FK_eventGivesBadges_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "BadgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventGivesBadges_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_LevelID",
                table: "Badges",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_eventGivesBadges_BadgeId",
                table: "eventGivesBadges",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MakerSpaceId",
                table: "Events",
                column: "MakerSpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventGivesBadges");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropColumn(
                name: "City",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "MakerSpaces");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "MakerSpaces",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<string>(
                name: "MakerSpaceCity",
                table: "MakerSpaces",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MakerSpacePostCode",
                table: "MakerSpaces",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MakerSpaceStreet",
                table: "MakerSpaces",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
