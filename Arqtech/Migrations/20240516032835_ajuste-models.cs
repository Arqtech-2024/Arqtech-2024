using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class ajustemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Lojas_MaterialId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Lojas");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Lojas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Lojas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Lojas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Lojas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_LojaId",
                table: "Materiais",
                column: "LojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Lojas_LojaId",
                table: "Materiais",
                column: "LojaId",
                principalTable: "Lojas",
                principalColumn: "LojaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Lojas_LojaId",
                table: "Materiais");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_LojaId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Lojas");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Lojas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Lojas_MaterialId",
                table: "Materiais",
                column: "MaterialId",
                principalTable: "Lojas",
                principalColumn: "LojaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
