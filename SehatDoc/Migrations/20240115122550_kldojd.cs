using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class kldojd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches");

            migrationBuilder.DropIndex(
                name: "IX_branches_HospitalProfileHospitalID",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "HospitalProfileHospitalID",
                table: "branches");

            migrationBuilder.AddColumn<int>(
                name: "hospitalid",
                table: "branches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hospitalid",
                table: "branches");

            migrationBuilder.AddColumn<int>(
                name: "HospitalProfileHospitalID",
                table: "branches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_branches_HospitalProfileHospitalID",
                table: "branches",
                column: "HospitalProfileHospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches",
                column: "HospitalProfileHospitalID",
                principalTable: "HospitalProfiles",
                principalColumn: "HospitalID");
        }
    }
}
