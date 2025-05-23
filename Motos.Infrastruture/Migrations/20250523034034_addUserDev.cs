using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motos.Infrastruture.Migrations
{
    /// <inheritdoc />
    public partial class addUserDev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "c7331179-06a2-4b04-84dd-f64f9689fa44", null, false, "Kaylan alexandre de paula sathler", false, null, null, "KAYLAN", "AQAAAAIAAYagAAAAEMZ57cR8Zuw29LroyRIPeGlFW/X8I25aQ1aAdsG17XTPxwJtjOHLXV91pLzSYM4SpA==", null, false, "185ced58-529c-4389-b30a-ab40073d5a9f", false, "Kaylan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
