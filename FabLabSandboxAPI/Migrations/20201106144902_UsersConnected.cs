using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class UsersConnected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_MakerSpaces_MakerSpaceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MakerSpaces_MakerSpaceId",
                table: "Machines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MakerSpaces",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MakerSpaces");

            migrationBuilder.AddColumn<int>(
                name: "MakerSpaceId",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MakerSpaces",
                table: "MakerSpaces",
                column: "MakerSpaceId");

            migrationBuilder.CreateTable(
                name: "makerSpaceHasUser",
                columns: table => new
                {
                    UserMId = table.Column<int>(nullable: false),
                    MakerSpaceId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makerSpaceHasUser", x => new { x.MakerSpaceId, x.UserMId });
                    table.ForeignKey(
                        name: "FK_makerSpaceHasUser_MakerSpaces_MakerSpaceId",
                        column: x => x.MakerSpaceId,
                        principalTable: "MakerSpaces",
                        principalColumn: "MakerSpaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_makerSpaceHasUser_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userAttendingEvent",
                columns: table => new
                {
                    UserAId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAttendingEvent", x => new { x.UserAId, x.EventId });
                    table.ForeignKey(
                        name: "FK_userAttendingEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userAttendingEvent_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userEarnedBadges",
                columns: table => new
                {
                    UserBId = table.Column<int>(nullable: false),
                    BadgeId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userEarnedBadges", x => new { x.UserBId, x.BadgeId });
                    table.ForeignKey(
                        name: "FK_userEarnedBadges_Badges_BadgeId",
                        column: x => x.BadgeId,
                        principalTable: "Badges",
                        principalColumn: "BadgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userEarnedBadges_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_makerSpaceHasUser_userId",
                table: "makerSpaceHasUser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userAttendingEvent_EventId",
                table: "userAttendingEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_userAttendingEvent_userId",
                table: "userAttendingEvent",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userEarnedBadges_BadgeId",
                table: "userEarnedBadges",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_userEarnedBadges_userId",
                table: "userEarnedBadges",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_MakerSpaces_MakerSpaceId",
                table: "Events",
                column: "MakerSpaceId",
                principalTable: "MakerSpaces",
                principalColumn: "MakerSpaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MakerSpaces_MakerSpaceId",
                table: "Machines",
                column: "MakerSpaceId",
                principalTable: "MakerSpaces",
                principalColumn: "MakerSpaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_MakerSpaces_MakerSpaceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MakerSpaces_MakerSpaceId",
                table: "Machines");

            migrationBuilder.DropTable(
                name: "makerSpaceHasUser");

            migrationBuilder.DropTable(
                name: "userAttendingEvent");

            migrationBuilder.DropTable(
                name: "userEarnedBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MakerSpaces",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "MakerSpaceId",
                table: "MakerSpaces");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MakerSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MakerSpaces",
                table: "MakerSpaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_MakerSpaces_MakerSpaceId",
                table: "Events",
                column: "MakerSpaceId",
                principalTable: "MakerSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MakerSpaces_MakerSpaceId",
                table: "Machines",
                column: "MakerSpaceId",
                principalTable: "MakerSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
