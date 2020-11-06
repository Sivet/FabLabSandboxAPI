using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class manytoManyCollections2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser");

            migrationBuilder.DropColumn(
                name: "UserBId",
                table: "userEarnedBadges");

            migrationBuilder.DropColumn(
                name: "UserEId",
                table: "userAttendingEvent");

            migrationBuilder.DropColumn(
                name: "UserMId",
                table: "makerSpaceHasUser");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "userEarnedBadges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "userAttendingEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "makerSpaceHasUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges",
                columns: new[] { "AppUserId", "BadgeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent",
                columns: new[] { "AppUserId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser",
                columns: new[] { "MakerSpaceId", "AppUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "userEarnedBadges");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "userAttendingEvent");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "makerSpaceHasUser");

            migrationBuilder.AddColumn<int>(
                name: "UserBId",
                table: "userEarnedBadges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserEId",
                table: "userAttendingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMId",
                table: "makerSpaceHasUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges",
                columns: new[] { "UserBId", "BadgeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent",
                columns: new[] { "UserEId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser",
                columns: new[] { "MakerSpaceId", "UserMId" });
        }
    }
}
