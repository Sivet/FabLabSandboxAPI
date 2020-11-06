using Microsoft.EntityFrameworkCore.Migrations;

namespace FabLabSandboxAPI.Migrations
{
    public partial class lOKALdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MakerSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakerSpaceName = table.Column<string>(maxLength: 250, nullable: false),
                    MakerSpacePostCode = table.Column<string>(maxLength: 4, nullable: false),
                    MakerSpaceStreet = table.Column<string>(maxLength: 100, nullable: false),
                    MakerSpaceCity = table.Column<string>(maxLength: 250, nullable: false),
                    IsAccepted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakerSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(maxLength: 150, nullable: false),
                    MachineDescription = table.Column<string>(nullable: false),
                    MakerSpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_MakerSpaces_MakerSpaceId",
                        column: x => x.MakerSpaceId,
                        principalTable: "MakerSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MakerSpaceId",
                table: "Machines",
                column: "MakerSpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MakerSpaces");
        }
    }
}
