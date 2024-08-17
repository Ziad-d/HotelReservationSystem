using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomsTableRemoveRoomStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
