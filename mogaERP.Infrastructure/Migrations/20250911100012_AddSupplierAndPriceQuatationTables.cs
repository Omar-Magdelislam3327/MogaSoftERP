using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mogaERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierAndPriceQuatationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Procurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ResponsibleName1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResponsibleName2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1050)", maxLength: 1050, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotations",
                schema: "Procurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QuotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseRequestId = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequestId2 = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceQuotations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceQuotations_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PriceQuotations_PurchaseRequests_PurchaseRequestId2",
                        column: x => x.PurchaseRequestId2,
                        principalSchema: "Procurement",
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceQuotations_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Procurement",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceQuotationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQuotationId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceQuotationItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceQuotationItems_PriceQuotations_PriceQuotationId",
                        column: x => x.PriceQuotationId,
                        principalSchema: "Procurement",
                        principalTable: "PriceQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                column: "PriceQuotationId",
                unique: true,
                filter: "[PriceQuotationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotationItems_ItemId",
                table: "PriceQuotationItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotationItems_PriceQuotationId",
                table: "PriceQuotationItems",
                column: "PriceQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_CreatedById",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "PurchaseRequestId2");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_SupplierId",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_UpdatedById",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CreatedById",
                schema: "Procurement",
                table: "Suppliers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UpdatedById",
                schema: "Procurement",
                table: "Suppliers",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_PriceQuotations_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                column: "PriceQuotationId",
                principalSchema: "Procurement",
                principalTable: "PriceQuotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_PriceQuotations_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropTable(
                name: "PriceQuotationItems");

            migrationBuilder.DropTable(
                name: "PriceQuotations",
                schema: "Procurement");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Procurement");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequests_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropColumn(
                name: "PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");
        }
    }
}
