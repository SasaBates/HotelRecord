using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRecord.Repository.Migrations
{
    public partial class boundaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelChains_HotelChainId",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelChainId",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelChains",
                type: "varchar(75)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelChains_HotelChainId",
                table: "Hotels",
                column: "HotelChainId",
                principalTable: "HotelChains",
                principalColumn: "HotelchainId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelChains_HotelChainId",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelChainId",
                table: "Hotels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelChains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelChains_HotelChainId",
                table: "Hotels",
                column: "HotelChainId",
                principalTable: "HotelChains",
                principalColumn: "HotelchainId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
