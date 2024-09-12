using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Purchase.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPurchaseHeaderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_PurchaseHeaders_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseHeaders",
                table: "PurchaseHeaders");

            migrationBuilder.RenameTable(
                name: "PurchaseHeaders",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseHeaders_PurchaseCode",
                table: "Purchases",
                newName: "IX_Purchases_PurchaseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseProducts_Purchases_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "PurchaseHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_PurchaseCode",
                table: "PurchaseHeaders",
                newName: "IX_PurchaseHeaders_PurchaseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseHeaders",
                table: "PurchaseHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseProducts_PurchaseHeaders_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId",
                principalTable: "PurchaseHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
