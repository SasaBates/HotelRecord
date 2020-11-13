using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRecord.Repository.Migrations
{
    public partial class VirtualHotelChain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelchainId",
                table: "HotelChains",
                newName: "HotelChainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelChainId",
                table: "HotelChains",
                newName: "HotelchainId");
        }
    }
}
