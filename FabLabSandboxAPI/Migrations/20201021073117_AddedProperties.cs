using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class AddedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "MakerSpaces",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "MakerSpaces",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "MakerSpaces",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "MakerSpaces",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "MakerSpaces");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "MakerSpaces");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MakerSpaces",
                newName: "name");
        }
    }
}
