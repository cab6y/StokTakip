using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Migrations
{
    /// <inheritdoc />
    public partial class productSizeDescriptio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StokTakipProductSizes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StokTakipProductSizes");
        }
    }
}
