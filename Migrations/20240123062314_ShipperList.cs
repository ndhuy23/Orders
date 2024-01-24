using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orders.Migrations
{
    /// <inheritdoc />
    public partial class ShipperList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "EMP001", "John" },
                    { 2, "EMP002", "William" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 2);
        }
    }
}
