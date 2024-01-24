using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Shippers_ShipperId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Shippers_ShipperId",
                table: "Deliveries",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "ShipperId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Shippers_ShipperId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Shippers_ShipperId",
                table: "Deliveries",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "ShipperId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
