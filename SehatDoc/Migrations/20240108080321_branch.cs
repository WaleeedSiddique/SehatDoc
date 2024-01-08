using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentHospitalProfile_HospitalProfiles_HospitalProfilesHospitalID",
                table: "DepartmentHospitalProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalProfiles_cities_CityId",
                table: "HospitalProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalProfiles_states_StateId",
                table: "HospitalProfiles");

            migrationBuilder.DropIndex(
                name: "IX_HospitalProfiles_CityId",
                table: "HospitalProfiles");

            migrationBuilder.DropIndex(
                name: "IX_HospitalProfiles_StateId",
                table: "HospitalProfiles");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "HospitalProfiles");

            migrationBuilder.DropColumn(
                name: "HospitalLocation",
                table: "HospitalProfiles");

            migrationBuilder.DropColumn(
                name: "HospitalNumber",
                table: "HospitalProfiles");

            migrationBuilder.DropColumn(
                name: "HospitalNumber2",
                table: "HospitalProfiles");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "HospitalProfiles");

            migrationBuilder.RenameColumn(
                name: "HospitalProfilesHospitalID",
                table: "DepartmentHospitalProfile",
                newName: "HospitalBranchID");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentHospitalProfile_HospitalProfilesHospitalID",
                table: "DepartmentHospitalProfile",
                newName: "IX_DepartmentHospitalProfile_HospitalBranchID");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalName",
                table: "HospitalProfiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    HospitalProfileHospitalID = table.Column<int>(type: "int", nullable: false),
                    HospitalLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.BranchID);
                    table.ForeignKey(
                        name: "FK_branches_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_branches_HospitalProfiles_HospitalProfileHospitalID",
                        column: x => x.HospitalProfileHospitalID,
                        principalTable: "HospitalProfiles",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_branches_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_branches_CityId",
                table: "branches",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_branches_HospitalProfileHospitalID",
                table: "branches",
                column: "HospitalProfileHospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_branches_StateId",
                table: "branches",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentHospitalProfile_branches_HospitalBranchID",
                table: "DepartmentHospitalProfile",
                column: "HospitalBranchID",
                principalTable: "branches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentHospitalProfile_branches_HospitalBranchID",
                table: "DepartmentHospitalProfile");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.RenameColumn(
                name: "HospitalBranchID",
                table: "DepartmentHospitalProfile",
                newName: "HospitalProfilesHospitalID");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentHospitalProfile_HospitalBranchID",
                table: "DepartmentHospitalProfile",
                newName: "IX_DepartmentHospitalProfile_HospitalProfilesHospitalID");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalName",
                table: "HospitalProfiles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "HospitalProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalLocation",
                table: "HospitalProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalNumber",
                table: "HospitalProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalNumber2",
                table: "HospitalProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "HospitalProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HospitalProfiles_CityId",
                table: "HospitalProfiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalProfiles_StateId",
                table: "HospitalProfiles",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentHospitalProfile_HospitalProfiles_HospitalProfilesHospitalID",
                table: "DepartmentHospitalProfile",
                column: "HospitalProfilesHospitalID",
                principalTable: "HospitalProfiles",
                principalColumn: "HospitalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalProfiles_cities_CityId",
                table: "HospitalProfiles",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalProfiles_states_StateId",
                table: "HospitalProfiles",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id");
        }
    }
}
