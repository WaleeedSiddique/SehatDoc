using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class checking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "branches");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalProfileHospitalID",
                table: "branches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches",
                column: "HospitalProfileHospitalID",
                principalTable: "HospitalProfiles",
                principalColumn: "HospitalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalProfileHospitalID",
                table: "branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                table: "branches",
                column: "HospitalProfileHospitalID",
                principalTable: "HospitalProfiles",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
