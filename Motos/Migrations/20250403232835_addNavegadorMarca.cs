using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Migrations
{
    /// <inheritdoc />
    public partial class addNavegadorMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "MotosM",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotosM_Marca_MarcaId",
                table: "MotosM");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "MotosM",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MotosM_Marca_MarcaId",
                table: "MotosM",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }
    }
}
