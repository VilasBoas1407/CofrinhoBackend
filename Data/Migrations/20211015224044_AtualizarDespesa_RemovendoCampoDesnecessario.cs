using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AtualizarDespesa_RemovendoCampoDesnecessario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Planejamento_IdPlanejamento",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_IdPlanejamento",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "IdPlanejamento",
                table: "Despesas");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanejamentoEntityId",
                table: "Despesas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_PlanejamentoEntityId",
                table: "Despesas",
                column: "PlanejamentoEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Planejamento_PlanejamentoEntityId",
                table: "Despesas",
                column: "PlanejamentoEntityId",
                principalTable: "Planejamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Planejamento_PlanejamentoEntityId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_PlanejamentoEntityId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "PlanejamentoEntityId",
                table: "Despesas");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPlanejamento",
                table: "Despesas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdPlanejamento",
                table: "Despesas",
                column: "IdPlanejamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Planejamento_IdPlanejamento",
                table: "Despesas",
                column: "IdPlanejamento",
                principalTable: "Planejamento",
                principalColumn: "Id");
        }
    }
}
