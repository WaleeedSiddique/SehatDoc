using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class diseaseIDinSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseID",
                table: "Specialities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_DiseaseID",
                table: "Specialities",
                column: "DiseaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Diseases_DiseaseID",
                table: "Specialities",
                column: "DiseaseID",
                principalTable: "Diseases",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Diseases_DiseaseID",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_DiseaseID",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "DiseaseID",
                table: "Specialities");
        }
    }
}
