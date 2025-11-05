using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentOrchestratorLite.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedAuthData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12a1d508-95f2-4fe2-a712-532fca8e5b9f", "12a1d508-95f2-4fe2-a712-532fca8e5b9f", "Writer", "WRITER" },
                    { "3ef9235c-df3d-4d09-a54e-03adc9ed2283", "3ef9235c-df3d-4d09-a54e-03adc9ed2283", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbbe523f-8929-44e0-b440-32ebd86f526d", 0, "f28b0e62-aa07-4616-86ed-344d01ce3a6e", "admin@paymentorchestrator.com", true, false, null, "ADMIN@PAYMENTORCHESTRATOR.COM", "ADMIN@PAYMENTORCHESTRATOR.COM", "AQAAAAIAAYagAAAAECfQsOEJ2vPLZnjyDBwFy1uPyTRW23oUOjJ6RHOVE1Q2Vx8uV6EY2IZyZ2/WYcd9BQ==", null, false, "f28b0e62-aa07-4616-86ed-344d01ce3a6e", false, "admin@paymentorchestrator.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "12a1d508-95f2-4fe2-a712-532fca8e5b9f", "dbbe523f-8929-44e0-b440-32ebd86f526d" },
                    { "3ef9235c-df3d-4d09-a54e-03adc9ed2283", "dbbe523f-8929-44e0-b440-32ebd86f526d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12a1d508-95f2-4fe2-a712-532fca8e5b9f", "dbbe523f-8929-44e0-b440-32ebd86f526d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ef9235c-df3d-4d09-a54e-03adc9ed2283", "dbbe523f-8929-44e0-b440-32ebd86f526d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12a1d508-95f2-4fe2-a712-532fca8e5b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef9235c-df3d-4d09-a54e-03adc9ed2283");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbbe523f-8929-44e0-b440-32ebd86f526d");
        }
    }
}
