using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Reservations;

namespace HotelReservationSystem.Models.Rooms
{
    public class Room : BaseModel
    {
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        public HashSet<RoomFacilities> RoomFacilities { get; set; }

        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
    }
}
