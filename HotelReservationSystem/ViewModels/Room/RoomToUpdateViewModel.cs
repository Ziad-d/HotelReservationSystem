using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.ViewModels.Room
{
    public class RoomToUpdateViewModel
    {
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        public List<RoomFacilities> Facilities { get; set; }
    }
}
