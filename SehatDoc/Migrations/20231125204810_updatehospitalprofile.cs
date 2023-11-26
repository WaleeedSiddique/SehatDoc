using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class updatehospitalprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalProfiles_Departments_DepartmentID",
                table: "HospitalProfiles");

            migrationBuilder.DropIndex(
                name: "IX_HospitalProfiles_DepartmentID",
                table: "HospitalProfiles");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "HospitalProfiles",
                newName: "City");

            migrationBuilder.CreateTable(
                name: "DepartmentHospitalProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentsDepartmentID = table.Column<int>(type: "int", nullable: false),
                    HospitalProfilesHospitalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentHospitalProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentHospitalProfile_Departments_DepartmentsDepartmentID",
                        column: x => x.DepartmentsDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentHospitalProfile_HospitalProfiles_HospitalProfilesHospitalID",
                        column: x => x.HospitalProfilesHospitalID,
                        principalTable: "HospitalProfiles",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHospitalProfile_DepartmentsDepartmentID",
                table: "DepartmentHospitalProfile",
                column: "DepartmentsDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHospitalProfile_HospitalProfilesHospitalID",
                table: "DepartmentHospitalProfile",
                column: "HospitalProfilesHospitalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentHospitalProfile");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "HospitalProfiles",
                newName: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalProfiles_DepartmentID",
                table: "HospitalProfiles",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalProfiles_Departments_DepartmentID",
                table: "HospitalProfiles",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
