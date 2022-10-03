using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Services.ProductAPI.Migrations
{
    public partial class imagesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://storageeco.blob.core.windows.net/storageeco/13.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://storageeco.blob.core.windows.net/storageecoe/13.jpg");
        }
    }
}
