using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Despesas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planejamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesReferencia = table.Column<int>(type: "int", nullable: false),
                    AnoReferencia = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planejamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planejamento_User_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoDespesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDespesa = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDespesa_User_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recorrencia = table.Column<int>(type: "int", nullable: false),
                    ValorParcela = table.Column<double>(type: "float", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    ParcelaAtual = table.Column<int>(type: "int", nullable: false),
                    GastoFixo = table.Column<bool>(type: "bit", nullable: false),
                    Quitado = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanejamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoDespesa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Planejamento_IdPlanejamento",
                        column: x => x.IdPlanejamento,
                        principalTable: "Planejamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesas_TipoDespesa_IdTipoDespesa",
                        column: x => x.IdTipoDespesa,
                        principalTable: "TipoDespesa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Despesas_User_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdPlanejamento",
                table: "Despesas",
                column: "IdPlanejamento");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdTipoDespesa",
                table: "Despesas",
                column: "IdTipoDespesa");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdUsuario",
                table: "Despesas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Planejamento_IdUsuario",
                table: "Planejamento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDespesa_IdUsuario",
                table: "TipoDespesa",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Planejamento");

            migrationBuilder.DropTable(
                name: "TipoDespesa");
        }
    }
}
