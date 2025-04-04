using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Migrations
{
    /// <inheritdoc />
    public partial class add_MarcaMoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarcaMoto",
                table: "MotosM",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcaMoto",
                table: "MotosM");
        }
    }
}
