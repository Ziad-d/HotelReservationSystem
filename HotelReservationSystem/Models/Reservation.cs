using HotelReservationSystem.Enums;

namespace HotelReservationSystem.Models
{
    public class Reservation : BaseModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public List<RoomReservation> RoomReservations { get; set; }
    }
}
