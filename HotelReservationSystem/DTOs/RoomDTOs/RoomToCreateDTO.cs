using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTOs.RoomDTOs
{
    public record RoomToCreateDTO
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public RoomType RoomType { get; set; }
    }
}
