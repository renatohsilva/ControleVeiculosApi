using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeiculos.Infra.Data.Migrations
{
    public partial class AdicionarRelacaoUsuarioTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Veiculos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Abastecimentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UsuarioId",
                table: "Veiculos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_UsuarioId",
                table: "Abastecimentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abastecimentos_Usuarios_UsuarioId",
                table: "Abastecimentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Usuarios_UsuarioId",
                table: "Veiculos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abastecimentos_Usuarios_UsuarioId",
                table: "Abastecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Usuarios_UsuarioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_UsuarioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Abastecimentos_UsuarioId",
                table: "Abastecimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Abastecimentos");
        }
    }
}
