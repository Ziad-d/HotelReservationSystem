using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.Models.Reservations
{
    public class Reservation : BaseModel
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfReservedDays { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
