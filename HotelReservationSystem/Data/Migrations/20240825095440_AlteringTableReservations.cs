using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteringTableReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfReservedDays",
                table: "Reservations");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reservation_CheckDates",
                table: "Reservations",
                sql: "[CheckOutDate] > [CheckInDate]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Reservation_CheckDates",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReservedDays",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
