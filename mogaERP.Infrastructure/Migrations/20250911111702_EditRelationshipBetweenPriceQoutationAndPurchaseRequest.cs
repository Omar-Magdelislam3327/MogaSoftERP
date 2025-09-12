using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mogaERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationshipBetweenPriceQoutationAndPurchaseRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceQuotations_PurchaseRequests_PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_PriceQuotations_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequests_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_PriceQuotations_PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.DropColumn(
                name: "PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.RenameColumn(
                name: "PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                newName: "AwardedQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_AwardedQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                column: "AwardedQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_PurchaseRequestId",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "PurchaseRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceQuotations_PurchaseRequests_PurchaseRequestId",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "PurchaseRequestId",
                principalSchema: "Procurement",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_PriceQuotations_AwardedQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                column: "AwardedQuotationId",
                principalSchema: "Procurement",
                principalTable: "PriceQuotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceQuotations_PurchaseRequests_PurchaseRequestId",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_PriceQuotations_AwardedQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequests_AwardedQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_PriceQuotations_PurchaseRequestId",
                schema: "Procurement",
                table: "PriceQuotations");

            migrationBuilder.RenameColumn(
                name: "AwardedQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                newName: "PriceQuotationId");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequests_PriceQuotationId",
                schema: "Procurement",
                table: "PurchaseRequests",
                column: "PriceQuotationId",
                unique: true,
                filter: "[PriceQuotationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotations_PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "PurchaseRequestId2");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceQuotations_PurchaseRequests_PurchaseRequestId2",
                schema: "Procurement",
                table: "PriceQuotations",
                column: "PurchaseRequestId2",
                principalSchema: "Procurement",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
