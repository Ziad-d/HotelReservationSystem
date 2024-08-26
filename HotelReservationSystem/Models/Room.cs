using HotelReservationSystem.Enums;

namespace HotelReservationSystem.Models
{
    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public RoomType RoomType { get; set; }

        public HashSet<RoomFacilities> RoomFacilities { get; set; }

        public List<Picture> Pictures { get; set; }

        public Reservation Reservation { get; set; }
        public int? ReservationId { get; set; }
    }
}
