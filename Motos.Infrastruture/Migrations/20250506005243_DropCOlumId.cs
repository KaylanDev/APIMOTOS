using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class DropCOlumId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
         name: "TempId",
         table: "MotosM",
         type: "int",
         nullable: false,
         defaultValue: 0);

            migrationBuilder.Sql("UPDATE MotosM SET TempId = Id");

         



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover a coluna recriada
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MotosM");

            // Recriar a coluna original sem a propriedade IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MotosM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
