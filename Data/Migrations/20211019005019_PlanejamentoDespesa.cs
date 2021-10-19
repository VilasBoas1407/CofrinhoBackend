using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PlanejamentoDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesaEntity_Despesas_IdDespesa",
                table: "PlanejamentoDespesaEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesaEntity_Planejamento_IdPlanejamento",
                table: "PlanejamentoDespesaEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesaEntity_User_IdUsuario",
                table: "PlanejamentoDespesaEntity");

            migrationBuilder.RenameTable(
                name: "PlanejamentoDespesaEntity",
                newName: "PlanejamentoDespesa");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuario",
                table: "PlanejamentoDespesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPlanejamento",
                table: "PlanejamentoDespesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDespesa",
                table: "PlanejamentoDespesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PlanejamentoDespesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "PlanejamentoDespesa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "PlanejamentoDespesa",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanejamentoDespesa",
                table: "PlanejamentoDespesa",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlanejamentoDespesa_IdDespesa",
                table: "PlanejamentoDespesa",
                column: "IdDespesa");

            migrationBuilder.CreateIndex(
                name: "IX_PlanejamentoDespesa_IdPlanejamento",
                table: "PlanejamentoDespesa",
                column: "IdPlanejamento");

            migrationBuilder.CreateIndex(
                name: "IX_PlanejamentoDespesa_IdUsuario",
                table: "PlanejamentoDespesa",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesa_Despesas_IdDespesa",
                table: "PlanejamentoDespesa",
                column: "IdDespesa",
                principalTable: "Despesas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesa_Planejamento_IdPlanejamento",
                table: "PlanejamentoDespesa",
                column: "IdPlanejamento",
                principalTable: "Planejamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesa_User_IdUsuario",
                table: "PlanejamentoDespesa",
                column: "IdUsuario",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesa_Despesas_IdDespesa",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesa_Planejamento_IdPlanejamento",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanejamentoDespesa_User_IdUsuario",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanejamentoDespesa",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropIndex(
                name: "IX_PlanejamentoDespesa_IdDespesa",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropIndex(
                name: "IX_PlanejamentoDespesa_IdPlanejamento",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropIndex(
                name: "IX_PlanejamentoDespesa_IdUsuario",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "PlanejamentoDespesa");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "PlanejamentoDespesa");

            migrationBuilder.RenameTable(
                name: "PlanejamentoDespesa",
                newName: "PlanejamentoDespesaEntity");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUsuario",
                table: "PlanejamentoDespesaEntity",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdPlanejamento",
                table: "PlanejamentoDespesaEntity",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDespesa",
                table: "PlanejamentoDespesaEntity",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesaEntity_Despesas_IdDespesa",
                table: "PlanejamentoDespesaEntity",
                column: "IdDespesa",
                principalTable: "Despesas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesaEntity_Planejamento_IdPlanejamento",
                table: "PlanejamentoDespesaEntity",
                column: "IdPlanejamento",
                principalTable: "Planejamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanejamentoDespesaEntity_User_IdUsuario",
                table: "PlanejamentoDespesaEntity",
                column: "IdUsuario",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
