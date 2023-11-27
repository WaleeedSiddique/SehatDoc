using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class adddoctorinhospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorHospitalProfile",
                columns: table => new
                {
                    DoctorHospitalProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorHospitalProfile", x => x.DoctorHospitalProfileID);
                    table.ForeignKey(
                        name: "FK_DoctorHospitalProfile_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorHospitalProfile_HospitalProfiles_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "HospitalProfiles",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHospitalProfile_DoctorID",
                table: "DoctorHospitalProfile",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHospitalProfile_HospitalID",
                table: "DoctorHospitalProfile",
                column: "HospitalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorHospitalProfile");
        }
    }
}
