using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class migrationAfterMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "MakerSpaces");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "MakerSpaces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "MakerSpaces");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "MakerSpaces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
