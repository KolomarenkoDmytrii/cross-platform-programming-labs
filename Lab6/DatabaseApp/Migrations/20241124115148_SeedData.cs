using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "LocationDetails" },
                values: new object[,]
                {
                    { 1, "Rivercity" },
                    { 2, "London" },
                    { 3, "Rome" }
                });

            migrationBuilder.InsertData(
                table: "RefAssetCategories",
                columns: new[] { "AssetCategoryCode", "AssetCategoryDescription" },
                values: new object[] { "DOMESTIC", "Domestic" });

            migrationBuilder.InsertData(
                table: "RefSizes",
                columns: new[] { "SizeCode", "SizeDescription" },
                values: new object[,]
                {
                    { "LARGE", "Large" },
                    { "MEDIUM", "Medium" },
                    { "SMALL", "Small" }
                });

            migrationBuilder.InsertData(
                table: "RefStatuses",
                columns: new[] { "StatusCode", "StatusDescription" },
                values: new object[,]
                {
                    { "CANCELLED", "Cancelled" },
                    { "DELIVERED", "Delivered" },
                    { "PAID", "Paid" }
                });

            migrationBuilder.InsertData(
                table: "RefAssetSupertypes",
                columns: new[] { "AssetSupertypeCode", "AssetCategoryCode", "AssetSupertypeDescription" },
                values: new object[] { "CUTLERY", "DOMESTIC", "Cutlery" });

            migrationBuilder.InsertData(
                table: "RefAssetTypes",
                columns: new[] { "AssetTypeCode", "AssetSupertypeCode", "AssetTypeDescription" },
                values: new object[] { "SPOON", "CUTLERY", "Spoon" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetID", "AssetName", "AssetTypeCode", "OtherDetails", "SizeCode" },
                values: new object[] { 1, "UltraSpoon", "SPOON", "Great ultra spoon", "SMALL" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RefSizes",
                keyColumn: "SizeCode",
                keyValue: "LARGE");

            migrationBuilder.DeleteData(
                table: "RefSizes",
                keyColumn: "SizeCode",
                keyValue: "MEDIUM");

            migrationBuilder.DeleteData(
                table: "RefStatuses",
                keyColumn: "StatusCode",
                keyValue: "CANCELLED");

            migrationBuilder.DeleteData(
                table: "RefStatuses",
                keyColumn: "StatusCode",
                keyValue: "DELIVERED");

            migrationBuilder.DeleteData(
                table: "RefStatuses",
                keyColumn: "StatusCode",
                keyValue: "PAID");

            migrationBuilder.DeleteData(
                table: "RefAssetTypes",
                keyColumn: "AssetTypeCode",
                keyValue: "SPOON");

            migrationBuilder.DeleteData(
                table: "RefSizes",
                keyColumn: "SizeCode",
                keyValue: "SMALL");

            migrationBuilder.DeleteData(
                table: "RefAssetSupertypes",
                keyColumn: "AssetSupertypeCode",
                keyValue: "CUTLERY");

            migrationBuilder.DeleteData(
                table: "RefAssetCategories",
                keyColumn: "AssetCategoryCode",
                keyValue: "DOMESTIC");
        }
    }
}
