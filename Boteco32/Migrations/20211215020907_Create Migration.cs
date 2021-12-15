using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boteco32.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    saldoEstoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    valorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido",
                        column: x => x.idPedido,
                        principalTable: "Pedido",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produto",
                        column: x => x.idProduto,
                        principalTable: "Produto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_idPedido",
                table: "ItemPedido",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_idProduto",
                table: "ItemPedido",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_idCliente",
                table: "Pedido",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
