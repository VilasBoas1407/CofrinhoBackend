using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemovendoCampoGastoFixo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GastoFixo",
                table: "Despesas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GastoFixo",
                table: "Despesas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
