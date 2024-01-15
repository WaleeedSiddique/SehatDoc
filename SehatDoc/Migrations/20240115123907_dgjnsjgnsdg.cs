using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class dgjnsjgnsdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_branches_hospitalid",
                table: "branches",
                column: "hospitalid");

            migrationBuilder.AddForeignKey(
                name: "FK_branches_HospitalProfiles_hospitalid",
                table: "branches",
                column: "hospitalid",
                principalTable: "HospitalProfiles",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_branches_HospitalProfiles_hospitalid",
                table: "branches");

            migrationBuilder.DropIndex(
                name: "IX_branches_hospitalid",
                table: "branches");
        }
    }
}
