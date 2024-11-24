using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LifeCyclePhases",
                columns: new[] { "LifeCycleCode", "LifeCycleDescription", "LifeCycleName" },
                values: new object[] { "START", "Start of a life cycle", "Start" });

            migrationBuilder.InsertData(
                table: "ResponsibleParties",
                columns: new[] { "PartyID", "PartyDetails" },
                values: new object[] { 1, "Johnsons Ltd." });

            migrationBuilder.InsertData(
                table: "AssetLifeCycleEvents",
                columns: new[] { "AssetLifeCycleEventID", "AssetID", "DateFrom", "DateTo", "LifeCycleCode", "LocationID", "PartyID", "StatusCode" },
                values: new object[] { 1, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "START", 1, 1, "DELIVERED" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssetLifeCycleEvents",
                keyColumn: "AssetLifeCycleEventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LifeCyclePhases",
                keyColumn: "LifeCycleCode",
                keyValue: "START");

            migrationBuilder.DeleteData(
                table: "ResponsibleParties",
                keyColumn: "PartyID",
                keyValue: 1);
        }
    }
}
