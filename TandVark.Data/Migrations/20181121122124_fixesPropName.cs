using Microsoft.EntityFrameworkCore.Migrations;

namespace TandVark.Data.Migrations
{
    public partial class fixesPropName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FldPhoneId",
                table: "TblPatients",
                newName: "FldPhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FldPhoneNumber",
                table: "TblPatients",
                newName: "FldPhoneId");
        }
    }
}
