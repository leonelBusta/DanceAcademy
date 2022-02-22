using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceMVCRepositoryAccesoDatos.Migrations
{
    public partial class DireccionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Colonia = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}
