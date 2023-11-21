using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class Hospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalProfiles_Departments_DepartmentID",
                table: "HospitalProfiles");

            migrationBuilder.DropIndex(
                name: "IX_HospitalProfiles_DepartmentID",
                table: "HospitalProfiles");
        }
    }
}
