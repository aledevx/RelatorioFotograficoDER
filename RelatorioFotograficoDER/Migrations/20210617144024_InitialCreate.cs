using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelatorioFotograficoDER.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordenacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrcamentoeletronicoId = table.Column<int>(type: "int", nullable: false),
                    RelacaoOrcamentoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenacaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdfAnexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfAnexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessoManutencaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatoriofotograficoId = table.Column<int>(type: "int", nullable: false),
                    CoordenacaoId = table.Column<int>(type: "int", nullable: false),
                    RelatorioAtesteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoManutencaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioAtesteAnexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatorioAtesteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioAtesteAnexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioAtestes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAprovacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioAtestes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioFotograficoAnexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatorioAtesteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioFotograficoAnexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioFotograficos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Veiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOrcamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patrimonio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kmh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioFotograficos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoEletronicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfAnexoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoEletronicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoEletronicos_PdfAnexos_PdfAnexoId",
                        column: x => x.PdfAnexoId,
                        principalTable: "PdfAnexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelacaoOrcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfAnexoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacaoOrcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelacaoOrcamentos_PdfAnexos_PdfAnexoId",
                        column: x => x.PdfAnexoId,
                        principalTable: "PdfAnexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoEletronicos_PdfAnexoId",
                table: "OrcamentoEletronicos",
                column: "PdfAnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacaoOrcamentos_PdfAnexoId",
                table: "RelacaoOrcamentos",
                column: "PdfAnexoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordenacaos");

            migrationBuilder.DropTable(
                name: "OrcamentoEletronicos");

            migrationBuilder.DropTable(
                name: "ProcessoManutencaos");

            migrationBuilder.DropTable(
                name: "RelacaoOrcamentos");

            migrationBuilder.DropTable(
                name: "RelatorioAtesteAnexos");

            migrationBuilder.DropTable(
                name: "RelatorioAtestes");

            migrationBuilder.DropTable(
                name: "RelatorioFotograficoAnexos");

            migrationBuilder.DropTable(
                name: "RelatorioFotograficos");

            migrationBuilder.DropTable(
                name: "PdfAnexos");
        }
    }
}
