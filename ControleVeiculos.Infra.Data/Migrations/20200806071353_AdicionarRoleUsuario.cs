using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeiculos.Infra.Data.Migrations
{
    public partial class AdicionarRoleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuarios");
        }
    }
}
