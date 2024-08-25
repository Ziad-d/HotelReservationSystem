using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Room;

namespace HotelReservationSystem.ViewModels.Room
{
    public class RoomToCreateViewModel
    {
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        // public List<RoomFacility> Facilities { get; set; }



    }
}
