using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeiculos.Infra.Data.Migrations
{
    public partial class InclusaoPlacaNaTabelaDeVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Veiculos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Veiculos");
        }
    }
}
