using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Room;

namespace HotelReservationSystem.DTOs.Room
{
    public class RoomToCreateDTO
    {
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        public List<RoomFacility> Facilities { get; set; }
    }
}
