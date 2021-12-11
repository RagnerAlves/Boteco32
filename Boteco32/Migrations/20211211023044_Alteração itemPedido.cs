using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boteco32.Migrations
{
    public partial class AlteraçãoitemPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ValorUnitario",
                table: "ItemPedido",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "ItemPedido");
        }
    }
}
