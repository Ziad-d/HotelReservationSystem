using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.RoomViewModels
{
    public class RoomToReturnViewModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public RoomType RoomType { get; set; }
        public int? ReservationId { get; set; }
        public IEnumerable<string> Facilities { get; set; }
    }
}
