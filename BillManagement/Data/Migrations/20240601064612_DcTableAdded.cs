using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class DcTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dctables",
                columns: table => new
                {
                    DcPk = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DcNo = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InvoiceCheck = table.Column<bool>(type: "INTEGER", nullable: true),
                    EwayBillNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dctables", x => x.DcPk);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PONumber = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HSN = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dcproducts",
                columns: table => new
                {
                    DcProductPk = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DcNo = table.Column<string>(type: "TEXT", nullable: true),
                    DcFk = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductFk = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EwayBillNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dcproducts", x => x.DcProductPk);
                    table.ForeignKey(
                        name: "FK_Dcproducts_Dctables_DcFk",
                        column: x => x.DcFk,
                        principalTable: "Dctables",
                        principalColumn: "DcPk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dcproducts_Products_ProductFk",
                        column: x => x.ProductFk,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dcproducts_DcFk",
                table: "Dcproducts",
                column: "DcFk");

            migrationBuilder.CreateIndex(
                name: "IX_Dcproducts_ProductFk",
                table: "Dcproducts",
                column: "ProductFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dcproducts");

            migrationBuilder.DropTable(
                name: "Dctables");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
