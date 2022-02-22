using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceMVCRepositoryAccesoDatos.Migrations
{
    public partial class generoTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Generos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descripcion",
                table: "Generos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
