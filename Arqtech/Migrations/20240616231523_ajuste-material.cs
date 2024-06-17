using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class ajustematerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ListaDeMateriais");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Materiais",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Materiais");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ListaDeMateriais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
