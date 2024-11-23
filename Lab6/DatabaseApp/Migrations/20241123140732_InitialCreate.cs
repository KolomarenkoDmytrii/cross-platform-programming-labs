using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LifeCyclePhases",
                columns: table => new
                {
                    LifeCycleCode = table.Column<string>(type: "TEXT", nullable: false),
                    LifeCycleName = table.Column<string>(type: "TEXT", nullable: false),
                    LifeCycleDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeCyclePhases", x => x.LifeCycleCode);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetCategories",
                columns: table => new
                {
                    AssetCategoryCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetCategoryDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetCategories", x => x.AssetCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "RefSizes",
                columns: table => new
                {
                    SizeCode = table.Column<string>(type: "TEXT", nullable: false),
                    SizeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSizes", x => x.SizeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefStatuses",
                columns: table => new
                {
                    StatusCode = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefStatuses", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "ResponsibleParties",
                columns: table => new
                {
                    PartyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartyDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleParties", x => x.PartyID);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetSupertypes",
                columns: table => new
                {
                    AssetSupertypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetCategoryCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetSupertypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetSupertypes", x => x.AssetSupertypeCode);
                    table.ForeignKey(
                        name: "FK_RefAssetSupertypes_RefAssetCategories_AssetCategoryCode",
                        column: x => x.AssetCategoryCode,
                        principalTable: "RefAssetCategories",
                        principalColumn: "AssetCategoryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetTypes",
                columns: table => new
                {
                    AssetTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetSupertypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetTypes", x => x.AssetTypeCode);
                    table.ForeignKey(
                        name: "FK_RefAssetTypes_RefAssetSupertypes_AssetSupertypeCode",
                        column: x => x.AssetSupertypeCode,
                        principalTable: "RefAssetSupertypes",
                        principalColumn: "AssetSupertypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    SizeCode = table.Column<string>(type: "TEXT", nullable: false),
                    AssetName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK_Assets_RefAssetTypes_AssetTypeCode",
                        column: x => x.AssetTypeCode,
                        principalTable: "RefAssetTypes",
                        principalColumn: "AssetTypeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_RefSizes_SizeCode",
                        column: x => x.SizeCode,
                        principalTable: "RefSizes",
                        principalColumn: "SizeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetLifeCycleEvents",
                columns: table => new
                {
                    AssetLifeCycleEventID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetID = table.Column<int>(type: "INTEGER", nullable: false),
                    LifeCycleCode = table.Column<string>(type: "TEXT", nullable: false),
                    LocationID = table.Column<int>(type: "INTEGER", nullable: false),
                    PartyID = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<string>(type: "TEXT", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLifeCycleEvents", x => x.AssetLifeCycleEventID);
                    table.ForeignKey(
                        name: "FK_AssetLifeCycleEvents_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLifeCycleEvents_LifeCyclePhases_LifeCycleCode",
                        column: x => x.LifeCycleCode,
                        principalTable: "LifeCyclePhases",
                        principalColumn: "LifeCycleCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLifeCycleEvents_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLifeCycleEvents_RefStatuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "RefStatuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLifeCycleEvents_ResponsibleParties_PartyID",
                        column: x => x.PartyID,
                        principalTable: "ResponsibleParties",
                        principalColumn: "PartyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetLifeCycleEvents_AssetID",
                table: "AssetLifeCycleEvents",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLifeCycleEvents_LifeCycleCode",
                table: "AssetLifeCycleEvents",
                column: "LifeCycleCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLifeCycleEvents_LocationID",
                table: "AssetLifeCycleEvents",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLifeCycleEvents_PartyID",
                table: "AssetLifeCycleEvents",
                column: "PartyID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLifeCycleEvents_StatusCode",
                table: "AssetLifeCycleEvents",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeCode",
                table: "Assets",
                column: "AssetTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SizeCode",
                table: "Assets",
                column: "SizeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RefAssetSupertypes_AssetCategoryCode",
                table: "RefAssetSupertypes",
                column: "AssetCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_RefAssetTypes_AssetSupertypeCode",
                table: "RefAssetTypes",
                column: "AssetSupertypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetLifeCycleEvents");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "LifeCyclePhases");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RefStatuses");

            migrationBuilder.DropTable(
                name: "ResponsibleParties");

            migrationBuilder.DropTable(
                name: "RefAssetTypes");

            migrationBuilder.DropTable(
                name: "RefSizes");

            migrationBuilder.DropTable(
                name: "RefAssetSupertypes");

            migrationBuilder.DropTable(
                name: "RefAssetCategories");
        }
    }
}
