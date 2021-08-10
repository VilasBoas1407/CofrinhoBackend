using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveFieldsHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "LoginHistory");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "LoginHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginHistory",
                table: "LoginHistory",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginHistory",
                table: "LoginHistory");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LoginHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "LoginHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
