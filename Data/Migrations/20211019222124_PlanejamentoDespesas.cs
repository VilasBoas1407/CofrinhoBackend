using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PlanejamentoDespesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanejamentoDespesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDespesa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanejamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanejamentoDespesas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanejamentoDespesas");

            migrationBuilder.CreateTable(
                name: "PlanejamentoDespesaEntity",
                columns: table => new
                {
                    IdDespesa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPlanejamento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PlanejamentoDespesaEntity_Despesas_IdDespesa",
                        column: x => x.IdDespesa,
                        principalTable: "Despesas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanejamentoDespesaEntity_Planejamento_IdPlanejamento",
                        column: x => x.IdPlanejamento,
                        principalTable: "Planejamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanejamentoDespesaEntity_User_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "User",
                        principalColumn: "Id");
                });
        }
    }
}
