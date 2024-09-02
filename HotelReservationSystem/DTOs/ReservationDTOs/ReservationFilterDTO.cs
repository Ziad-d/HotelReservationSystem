using HotelReservationSystem.Enums;

namespace HotelReservationSystem.DTOs.ReservationDTOs
{
    public class ReservationFilterDTO
    {
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public ReservationStatus? ReservationStatus { get; set; }
    }
}
