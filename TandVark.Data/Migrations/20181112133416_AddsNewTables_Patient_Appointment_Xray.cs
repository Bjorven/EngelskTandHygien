using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TandVark.Data.Migrations
{
    public partial class AddsNewTables_Patient_Appointment_Xray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblUsers_TblUserTypes_UserTypeId",
                table: "TblUsers");

            migrationBuilder.RenameColumn(
                name: "FldId",
                table: "TblUserTypes",
                newName: "FldUserTypeId");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "TblUsers",
                newName: "FldUserTypeId");

            migrationBuilder.RenameColumn(
                name: "FldId",
                table: "TblUsers",
                newName: "FldUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TblUsers_UserTypeId",
                table: "TblUsers",
                newName: "IX_TblUsers_FldUserTypeId");

            migrationBuilder.CreateTable(
                name: "TblPatients",
                columns: table => new
                {
                    FldPatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FldFirstName = table.Column<string>(nullable: true),
                    FldLastName = table.Column<string>(nullable: true),
                    FldSSnumber = table.Column<string>(maxLength: 12, nullable: false),
                    FldAddress = table.Column<string>(nullable: true),
                    FldPhoneId = table.Column<string>(nullable: true),
                    FldEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPatients", x => x.FldPatientId);
                });

            migrationBuilder.CreateTable(
                name: "TblAppointments",
                columns: table => new
                {
                    FldAppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FldAppointmentBegin = table.Column<DateTime>(nullable: false),
                    FldAppointmentEnd = table.Column<DateTime>(nullable: false),
                    FldDenistIdFK = table.Column<int>(nullable: false),
                    FldPatientFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAppointments", x => x.FldAppointmentId);
                    table.ForeignKey(
                        name: "FK_TblAppointments_TblUsers_FldDenistIdFK",
                        column: x => x.FldDenistIdFK,
                        principalTable: "TblUsers",
                        principalColumn: "FldUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAppointments_TblPatients_FldPatientFK",
                        column: x => x.FldPatientFK,
                        principalTable: "TblPatients",
                        principalColumn: "FldPatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblXrays",
                columns: table => new
                {
                    FldXrayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FldXrayURL = table.Column<string>(nullable: true),
                    FldAppointmentFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblXrays", x => x.FldXrayId);
                    table.ForeignKey(
                        name: "FK_TblXrays_TblAppointments_FldAppointmentFK",
                        column: x => x.FldAppointmentFK,
                        principalTable: "TblAppointments",
                        principalColumn: "FldAppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAppointments_FldDenistIdFK",
                table: "TblAppointments",
                column: "FldDenistIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_TblAppointments_FldPatientFK",
                table: "TblAppointments",
                column: "FldPatientFK");

            migrationBuilder.CreateIndex(
                name: "IX_TblXrays_FldAppointmentFK",
                table: "TblXrays",
                column: "FldAppointmentFK");

            migrationBuilder.AddForeignKey(
                name: "FK_TblUsers_TblUserTypes_FldUserTypeId",
                table: "TblUsers",
                column: "FldUserTypeId",
                principalTable: "TblUserTypes",
                principalColumn: "FldUserTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblUsers_TblUserTypes_FldUserTypeId",
                table: "TblUsers");

            migrationBuilder.DropTable(
                name: "TblXrays");

            migrationBuilder.DropTable(
                name: "TblAppointments");

            migrationBuilder.DropTable(
                name: "TblPatients");

            migrationBuilder.RenameColumn(
                name: "FldUserTypeId",
                table: "TblUserTypes",
                newName: "FldId");

            migrationBuilder.RenameColumn(
                name: "FldUserTypeId",
                table: "TblUsers",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "FldUserId",
                table: "TblUsers",
                newName: "FldId");

            migrationBuilder.RenameIndex(
                name: "IX_TblUsers_FldUserTypeId",
                table: "TblUsers",
                newName: "IX_TblUsers_UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblUsers_TblUserTypes_UserTypeId",
                table: "TblUsers",
                column: "UserTypeId",
                principalTable: "TblUserTypes",
                principalColumn: "FldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
