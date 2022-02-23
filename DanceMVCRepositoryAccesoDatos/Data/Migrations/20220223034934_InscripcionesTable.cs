using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceMVCRepositoryAccesoDatos.Migrations
{
    public partial class InscripcionesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incripciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(nullable: false),
                    Aprendices_Id = table.Column<int>(nullable: false),
                    Instructores_Id = table.Column<int>(nullable: false),
                    Instructor_Id = table.Column<int>(nullable: false),
                    Direccion_Id = table.Column<int>(nullable: false),
                    Genero_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incripciones_Aprendices_Aprendices_Id",
                        column: x => x.Aprendices_Id,
                        principalTable: "Aprendices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incripciones_Direccion_Direccion_Id",
                        column: x => x.Direccion_Id,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incripciones_Generos_Genero_Id",
                        column: x => x.Genero_Id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incripciones_Instructores_Instructor_Id",
                        column: x => x.Instructor_Id,
                        principalTable: "Instructores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incripciones_Aprendices_Id",
                table: "Incripciones",
                column: "Aprendices_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Incripciones_Direccion_Id",
                table: "Incripciones",
                column: "Direccion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Incripciones_Genero_Id",
                table: "Incripciones",
                column: "Genero_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Incripciones_Instructor_Id",
                table: "Incripciones",
                column: "Instructor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incripciones");
        }
    }
}
