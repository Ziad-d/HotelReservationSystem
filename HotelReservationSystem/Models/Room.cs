using HotelReservationSystem.Enums;

namespace HotelReservationSystem.Models
{
    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }

        public HashSet<RoomFacility> RoomFacilities { get; set; }

        public List<Picture> Pictures { get; set; }

        public List<RoomReservation> RoomReservations { get; set; }
    }
}
