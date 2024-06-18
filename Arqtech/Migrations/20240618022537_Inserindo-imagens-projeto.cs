using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class Inserindoimagensprojeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagemProjetoId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImagensProjetos",
                columns: table => new
                {
                    ImagemProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProjetos", x => x.ImagemProjetoId);
                    table.ForeignKey(
                        name: "FK_ImagensProjetos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProjetos_ProjetoId",
                table: "ImagensProjetos",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProjetos");

            migrationBuilder.DropColumn(
                name: "ImagemProjetoId",
                table: "Projetos");
        }
    }
}
