using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class ajustandoChaveEstrangeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
           

            migrationBuilder.AddForeignKey(
                name: "FK_MotosM_Marca_MarcaId",
                table: "MotosM",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotosM_Marca_MarcaId",
                table: "MotosM");



        }
    }
}
