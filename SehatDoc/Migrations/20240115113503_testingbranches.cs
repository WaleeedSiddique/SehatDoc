using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class testingbranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HospitalLocation",
                table: "branches",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "branches");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "branches",
                newName: "HospitalLocation");
        }
    }
}
