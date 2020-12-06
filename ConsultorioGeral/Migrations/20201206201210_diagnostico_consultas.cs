using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioGeral.Migrations
{
    public partial class diagnostico_consultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiagnosticoId",
                table: "Consultas",
                type: "bigint",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Diagnosticos_DiagnosticoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_DiagnosticoId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "DiagnosticoId",
                table: "Consultas");
        }
    }
}
