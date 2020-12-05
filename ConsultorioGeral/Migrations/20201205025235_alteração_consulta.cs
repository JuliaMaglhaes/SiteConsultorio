using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioGeral.Migrations
{
    public partial class alteração_consulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Medicos_MedicoId1",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_MedicoId1",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "MedicoId1",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "MedicoEsp",
                table: "Consultas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MedicoId1",
                table: "Medicos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicoEsp",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_MedicoId1",
                table: "Medicos",
                column: "MedicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Medicos_MedicoId1",
                table: "Medicos",
                column: "MedicoId1",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
