using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baiktr03.Data.Migrations
{
    /// <inheritdoc />
    public partial class buonhangcam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Order_OrderId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_OrderId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "supplier",
                table: "Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Supplier",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "supplierId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_supplierId",
                table: "Order",
                column: "supplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Supplier_supplierId",
                table: "Order",
                column: "supplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Supplier_supplierId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_supplierId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "supplierId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "Supplier",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "supplier",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_OrderId",
                table: "Supplier",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Order_OrderId",
                table: "Supplier",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
