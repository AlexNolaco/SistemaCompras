using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class DesafioSolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("5986fce2-77c6-428c-baab-d7ae62559030"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao" },
                values: new object[] { new Guid("1cd0c1a8-3ac6-4d01-85eb-cc54de9112e5"), 1, "Descricao01", "Produto01", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("1cd0c1a8-3ac6-4d01-85eb-cc54de9112e5"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao" },
                values: new object[] { new Guid("5986fce2-77c6-428c-baab-d7ae62559030"), 1, "Descricao01", "Produto01", 1 });
        }
    }
}
