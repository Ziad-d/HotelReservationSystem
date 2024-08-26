namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToReturnViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<int> RoomIDs { get; set; }
    }
}
