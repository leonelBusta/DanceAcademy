using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceMVCRepositoryAccesoDatos.Migrations
{
    public partial class AprendicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aprendices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    ApPaterno = table.Column<string>(nullable: false),
                    ApMaterno = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    UrlFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprendices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aprendices");
        }
    }
}
