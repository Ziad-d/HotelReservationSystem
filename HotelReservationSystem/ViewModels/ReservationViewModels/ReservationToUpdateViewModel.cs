namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToUpdateViewModel
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfReservedDays { get; set; }
        public bool IsCanceled { get; set; } = false;

        //public List<Room> Rooms { get; set; }

    }
}
