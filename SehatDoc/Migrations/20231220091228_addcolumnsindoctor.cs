using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class addcolumnsindoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CityId",
                table: "Doctors",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_StateId",
                table: "Doctors",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_cities_CityId",
                table: "Doctors",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_states_StateId",
                table: "Doctors",
                column: "StateId",
                principalTable: "states",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_cities_CityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_states_StateId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CityId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_StateId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
