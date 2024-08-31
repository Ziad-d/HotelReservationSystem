using HotelReservationSystem.Enums;

namespace HotelReservationSystem.DTOs.ReservationDTOs
{
    public class ReservationToReturnDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public List<int> RoomsNumber { get; set; }
    }
}
