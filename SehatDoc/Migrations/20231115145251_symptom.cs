using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SehatDoc.Migrations
{
    public partial class symptom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymptomName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SymptomImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SymptomDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Symptoms");
        }
    }
}
