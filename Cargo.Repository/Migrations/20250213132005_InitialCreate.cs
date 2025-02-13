using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cargo.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierIsActive = table.Column<bool>(type: "bit", nullable: false),
                    CarrierPlusDesiCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.CarrierId);
                });

            migrationBuilder.CreateTable(
                name: "CarriersConfiguration",
                columns: table => new
                {
                    CarrierConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    CarrierMaxDesi = table.Column<int>(type: "int", nullable: false),
                    CarrierMinDesi = table.Column<int>(type: "int", nullable: false),
                    CarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarriersConfiguration", x => x.CarrierConfigurationId);
                    table.ForeignKey(
                        name: "FK_CarriersConfiguration_Carrier_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carrier",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDesi = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Carrier_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carrier",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarriersConfiguration_CarrierId",
                table: "CarriersConfiguration",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarrierId",
                table: "Orders",
                column: "CarrierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarriersConfiguration");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carrier");
        }
    }
}
