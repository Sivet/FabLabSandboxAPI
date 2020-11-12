using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class manytoManyCollections3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_makerSpaceHasUser_AspNetUsers_userId",
                table: "makerSpaceHasUser");

            migrationBuilder.DropForeignKey(
                name: "FK_userAttendingEvent_AspNetUsers_userId",
                table: "userAttendingEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_userEarnedBadges_AspNetUsers_userId",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges");

            migrationBuilder.DropIndex(
                name: "IX_userEarnedBadges_userId",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropIndex(
                name: "IX_userAttendingEvent_userId",
                table: "userAttendingEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser");

            migrationBuilder.DropIndex(
                name: "IX_makerSpaceHasUser_userId",
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

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "userEarnedBadges",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "userEarnedBadges",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "userAttendingEvent",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "userAttendingEvent",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "makerSpaceHasUser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "makerSpaceHasUser",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges",
                columns: new[] { "userId", "BadgeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent",
                columns: new[] { "userId", "EventId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser",
                columns: new[] { "MakerSpaceId", "userId" });

            migrationBuilder.CreateIndex(
                name: "IX_userEarnedBadges_userId1",
                table: "userEarnedBadges",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_userAttendingEvent_userId1",
                table: "userAttendingEvent",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_makerSpaceHasUser_userId1",
                table: "makerSpaceHasUser",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_makerSpaceHasUser_AspNetUsers_userId1",
                table: "makerSpaceHasUser",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAttendingEvent_AspNetUsers_userId1",
                table: "userAttendingEvent",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userEarnedBadges_AspNetUsers_userId1",
                table: "userEarnedBadges",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_makerSpaceHasUser_AspNetUsers_userId1",
                table: "makerSpaceHasUser");

            migrationBuilder.DropForeignKey(
                name: "FK_userAttendingEvent_AspNetUsers_userId1",
                table: "userAttendingEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_userEarnedBadges_AspNetUsers_userId1",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userEarnedBadges",
                table: "userEarnedBadges");

            migrationBuilder.DropIndex(
                name: "IX_userEarnedBadges_userId1",
                table: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropIndex(
                name: "IX_userAttendingEvent_userId1",
                table: "userAttendingEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_makerSpaceHasUser",
                table: "makerSpaceHasUser");

            migrationBuilder.DropIndex(
                name: "IX_makerSpaceHasUser_userId1",
                table: "makerSpaceHasUser");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "userEarnedBadges");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "userAttendingEvent");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "makerSpaceHasUser");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "userEarnedBadges",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "userEarnedBadges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "userAttendingEvent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "userAttendingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "makerSpaceHasUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "makerSpaceHasUser",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_userEarnedBadges_userId",
                table: "userEarnedBadges",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userAttendingEvent_userId",
                table: "userAttendingEvent",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_makerSpaceHasUser_userId",
                table: "makerSpaceHasUser",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_makerSpaceHasUser_AspNetUsers_userId",
                table: "makerSpaceHasUser",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAttendingEvent_AspNetUsers_userId",
                table: "userAttendingEvent",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userEarnedBadges_AspNetUsers_userId",
                table: "userEarnedBadges",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
