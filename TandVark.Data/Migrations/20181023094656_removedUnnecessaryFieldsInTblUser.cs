using Microsoft.EntityFrameworkCore.Migrations;

namespace TandVark.Data.Migrations
{
    public partial class removedUnnecessaryFieldsInTblUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FldEmpType",
                table: "TblUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FldEmpType",
                table: "TblUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
