using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicECommerceExample.Migrations
{
    /// <inheritdoc />
    public partial class OrderHasCustomerAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "AccountNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerAccountNumber",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerAccountNumber",
                table: "Orders",
                column: "CustomerAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerAccountNumber",
                table: "Orders",
                column: "CustomerAccountNumber",
                principalTable: "Customers",
                principalColumn: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerAccountNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerAccountNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerAccountNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Customers",
                newName: "Id");
        }
    }
}
