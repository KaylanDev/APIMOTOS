using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Migrations
{
    /// <inheritdoc />
    public partial class sincronizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
              name: "Marca",
             table: "MotosM");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
