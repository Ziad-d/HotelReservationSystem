using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.RoomViewModels
{
    public class RoomToUpdateViewModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public RoomType RoomType { get; set; }
    }
}
