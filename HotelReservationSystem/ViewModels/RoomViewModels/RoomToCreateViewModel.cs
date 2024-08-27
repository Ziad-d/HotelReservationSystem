using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.RoomViewModels
{
    public record RoomToCreateViewModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
    }
}
