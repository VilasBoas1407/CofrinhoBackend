using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TipoDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesasEntity",
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
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPlanejamento = table.Column<int>(type: "int", nullable: false),
                    PlanejamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTipoDespesa = table.Column<int>(type: "int", nullable: false),
                    TipoDespesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespesasEntity_Planejamento_PlanejamentoId",
                        column: x => x.PlanejamentoId,
                        principalTable: "Planejamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesasEntity_TipoDespesa_TipoDespesaId",
                        column: x => x.TipoDespesaId,
                        principalTable: "TipoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesasEntity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DespesasEntity_PlanejamentoId",
                table: "DespesasEntity",
                column: "PlanejamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesasEntity_TipoDespesaId",
                table: "DespesasEntity",
                column: "TipoDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesasEntity_UserId",
                table: "DespesasEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDespesa_IdUsuario",
                table: "TipoDespesa",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesasEntity");

            migrationBuilder.DropTable(
                name: "TipoDespesa");
        }
    }
}
