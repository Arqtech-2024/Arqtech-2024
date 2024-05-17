using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class ajusteprojetomodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_ListaDeMateriais_ListaMaterialId",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "ListaMaterialId",
                table: "Projetos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EtapaId",
                table: "Projetos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_ListaDeMateriais_ListaMaterialId",
                table: "Projetos",
                column: "ListaMaterialId",
                principalTable: "ListaDeMateriais",
                principalColumn: "ListaMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_ListaDeMateriais_ListaMaterialId",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "ListaMaterialId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EtapaId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_ListaDeMateriais_ListaMaterialId",
                table: "Projetos",
                column: "ListaMaterialId",
                principalTable: "ListaDeMateriais",
                principalColumn: "ListaMaterialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
