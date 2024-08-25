using HotelReservationSystem.Enums;

namespace HotelReservationSystem.Models.Room
{
    public class Room : BaseModel
    {
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        public HashSet<RoomFacilities> RoomFacilities { get; set; }
    }
}
