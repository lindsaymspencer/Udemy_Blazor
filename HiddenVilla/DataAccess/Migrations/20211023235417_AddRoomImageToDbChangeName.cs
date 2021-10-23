using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddRoomImageToDbChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomImagess_HotelRooms_RoomId",
                table: "HotelRoomImagess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoomImagess",
                table: "HotelRoomImagess");

            migrationBuilder.RenameTable(
                name: "HotelRoomImagess",
                newName: "HotelRoomImages");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoomImagess_RoomId",
                table: "HotelRoomImages",
                newName: "IX_HotelRoomImages_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoomImages",
                table: "HotelRoomImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomImages_HotelRooms_RoomId",
                table: "HotelRoomImages",
                column: "RoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoomImages_HotelRooms_RoomId",
                table: "HotelRoomImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRoomImages",
                table: "HotelRoomImages");

            migrationBuilder.RenameTable(
                name: "HotelRoomImages",
                newName: "HotelRoomImagess");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoomImages_RoomId",
                table: "HotelRoomImagess",
                newName: "IX_HotelRoomImagess_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRoomImagess",
                table: "HotelRoomImagess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoomImagess_HotelRooms_RoomId",
                table: "HotelRoomImagess",
                column: "RoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
