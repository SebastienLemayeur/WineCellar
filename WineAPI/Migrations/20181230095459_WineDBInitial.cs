using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineAPI.Migrations
{
    public partial class WineDBInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DrinkBefore = table.Column<int>(nullable: false),
                    PurchasedOn = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    ProducerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wine_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wine_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "Country", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "France", "Union de producteurs de Saint-Emilion", "Saint-Emilion" },
                    { 2, "France", "André Lurton", "Bordeaux" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Red wines", "Red" },
                    { 2, "White wines", "White" },
                    { 3, "Wines best suited for dessert", "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Wine",
                columns: new[] { "Id", "Amount", "DrinkBefore", "Name", "Price", "ProducerId", "PurchasedOn", "TypeId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 2018, "Tour de Bonnet", 0m, null, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2013 },
                    { 2, 5, 2016, "Saint-Emilion Grand Cru", 13.99m, null, new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2010 },
                    { 3, 1, 0, "Tour de Bonnet", 13.99m, null, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2013 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wine_ProducerId",
                table: "Wine",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_TypeId",
                table: "Wine",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wine");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
