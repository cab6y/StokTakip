using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Migrations
{
    /// <inheritdoc />
    public partial class removeForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokTakipProductSizes_StokTakipProduct_ProductId",
                table: "StokTakipProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_StokTakipProductSizes_ProductId",
                table: "StokTakipProductSizes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StokTakipProductSizes_ProductId",
                table: "StokTakipProductSizes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokTakipProductSizes_StokTakipProduct_ProductId",
                table: "StokTakipProductSizes",
                column: "ProductId",
                principalTable: "StokTakipProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
