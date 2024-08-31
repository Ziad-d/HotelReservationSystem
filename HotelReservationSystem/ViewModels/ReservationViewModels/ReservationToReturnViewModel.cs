using HotelReservationSystem.Enums;

namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToReturnViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public List<int> RoomsNumber { get; set; }
    }
}
