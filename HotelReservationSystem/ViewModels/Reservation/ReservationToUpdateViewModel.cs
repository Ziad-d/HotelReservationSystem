using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.ViewModels.Room
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
