using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mogaERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDataInPriceQuatationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "QuotationDate",
                schema: "Procurement",
                table: "PriceQuotations",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "QuotationDate",
                schema: "Procurement",
                table: "PriceQuotations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Procurement",
                table: "PriceQuotations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
