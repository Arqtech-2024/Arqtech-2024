using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arqtech.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnprojeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Projetos");
        }
    }
}
