using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceMVCRepositoryAccesoDatos.Migrations
{
    public partial class instructoresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    ApPaterno = table.Column<string>(nullable: false),
                    ApMaterno = table.Column<string>(nullable: false),
                    UrlFoto = table.Column<string>(nullable: true),
                    CodigoInstructor = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructores");
        }
    }
}
