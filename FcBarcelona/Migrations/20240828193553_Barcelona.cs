using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcBarcelona.Migrations
{
    public partial class Barcelona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plantilla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantilla", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantilla_Nombre",
                table: "Plantilla",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plantilla");
        }
    }
}
