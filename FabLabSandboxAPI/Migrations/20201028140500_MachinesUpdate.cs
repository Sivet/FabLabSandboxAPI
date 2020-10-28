using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class MachinesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineSerialNumber",
                table: "Machines",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineSerialNumber",
                table: "Machines");
        }
    }
}
