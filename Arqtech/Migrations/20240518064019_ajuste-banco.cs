using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class ajustebanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etapas");

            migrationBuilder.DropColumn(
                name: "EtapaId",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Materiais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Materiais");

            migrationBuilder.AddColumn<int>(
                name: "EtapaId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    EtapaId = table.Column<int>(type: "int", nullable: false),
                    DescricaoEtapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiasCorridos = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    NomeEtapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.EtapaId);
                    table.ForeignKey(
                        name: "FK_Etapas_Projetos_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
