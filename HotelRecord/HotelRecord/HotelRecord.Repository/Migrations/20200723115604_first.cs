using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRecord.Repository.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelChains",
                columns: table => new
                {
                    HotelchainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    YearOfEstablishment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelChains", x => x.HotelchainId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OpeningYear = table.Column<DateTime>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    NumberOfRooms = table.Column<int>(nullable: false),
                    HotelChainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_HotelChains_HotelChainId",
                        column: x => x.HotelChainId,
                        principalTable: "HotelChains",
                        principalColumn: "HotelchainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelChainId",
                table: "Hotels",
                column: "HotelChainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "HotelChains");
        }
    }
}
