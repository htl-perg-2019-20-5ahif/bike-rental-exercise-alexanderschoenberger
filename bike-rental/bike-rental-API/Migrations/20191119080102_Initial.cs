using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bike_rental_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Bikes_BikeID",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerID",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Rentals",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "BikeID",
                table: "Rentals",
                newName: "BikeId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerID",
                table: "Rentals",
                newName: "IX_Rentals_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_BikeID",
                table: "Rentals",
                newName: "IX_Rentals_BikeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCosts",
                table: "Rentals",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Customers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "RentalPriceForFirstHour",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "RentalPriceForAdditionalHour",
                table: "Bikes",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfLastService",
                table: "Bikes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Bikes_BikeId",
                table: "Rentals",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Bikes_BikeId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Rentals",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "BikeId",
                table: "Rentals",
                newName: "BikeID");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                newName: "IX_Rentals_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_BikeId",
                table: "Rentals",
                newName: "IX_Rentals_BikeID");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCosts",
                table: "Rentals",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Customers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<double>(
                name: "RentalPriceForFirstHour",
                table: "Bikes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "RentalPriceForAdditionalHour",
                table: "Bikes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfLastService",
                table: "Bikes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Bikes_BikeID",
                table: "Rentals",
                column: "BikeID",
                principalTable: "Bikes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerID",
                table: "Rentals",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
