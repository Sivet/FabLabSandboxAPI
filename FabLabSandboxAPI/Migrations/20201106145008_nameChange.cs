using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class nameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropColumn(
                name: "UserAId",
                table: "userAttendingEvent");

            migrationBuilder.AddColumn<int>(
                name: "UserEId",
                table: "userAttendingEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent",
                columns: new[] { "UserEId", "EventId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent");

            migrationBuilder.DropColumn(
                name: "UserEId",
                table: "userAttendingEvent");

            migrationBuilder.AddColumn<int>(
                name: "UserAId",
                table: "userAttendingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAttendingEvent",
                table: "userAttendingEvent",
                columns: new[] { "UserAId", "EventId" });
        }
    }
}
