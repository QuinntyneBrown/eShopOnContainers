using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Catalog_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                schema: "Catalog",
                columns: table => new
                {
                    CatalogBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.CatalogBrandId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                schema: "Catalog",
                columns: table => new
                {
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.CatalogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                schema: "Catalog",
                columns: table => new
                {
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PictureFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    RestockThreshold = table.Column<int>(type: "int", nullable: false),
                    OnReorder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.CatalogItemId);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalSchema: "Catalog",
                        principalTable: "CatalogBrand",
                        principalColumn: "CatalogBrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "Catalog",
                        principalTable: "CatalogType",
                        principalColumn: "CatalogTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogBrandId",
                schema: "Catalog",
                table: "CatalogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogTypeId",
                schema: "Catalog",
                table: "CatalogItems",
                column: "CatalogTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogBrand",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogType",
                schema: "Catalog");
        }
    }
}
