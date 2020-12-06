using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioGeral.Migrations
{
    public partial class remocao_diagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_DiagnosticoId",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "DiagnosticoId",
                table: "Consultas",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Consultas",
                newName: "DiagnosticoId");

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    DiagnosticoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.DiagnosticoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_DiagnosticoId",
                table: "Consultas",
                column: "DiagnosticoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoId",
                table: "Consultas",
                column: "DiagnosticoId",
                principalTable: "Diagnosticos",
                principalColumn: "DiagnosticoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
