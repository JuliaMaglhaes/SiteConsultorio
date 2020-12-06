using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioGeral.Migrations
{
    public partial class remocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Consultas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
