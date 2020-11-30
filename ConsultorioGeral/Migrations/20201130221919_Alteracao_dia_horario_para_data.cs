using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioGeral.Migrations
{
    public partial class Alteracao_dia_horario_para_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "Consultas",
                newName: "Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Consultas",
                newName: "Horario");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dia",
                table: "Consultas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
