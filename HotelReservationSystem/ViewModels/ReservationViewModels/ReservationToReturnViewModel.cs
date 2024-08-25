using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToReturnViewModel
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfReservedDays { get; set; }
        //public List<Room> Rooms { get; set; }

    }
}
