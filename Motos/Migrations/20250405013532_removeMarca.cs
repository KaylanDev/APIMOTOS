using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Migrations
{
    /// <inheritdoc />
    public partial class removeMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcaMoto",
                table: "MotosM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarcaMoto",
                table: "MotosM",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
