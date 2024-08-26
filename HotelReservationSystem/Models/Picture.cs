namespace HotelReservationSystem.Models
{
    public class Picture : BaseModel
    {
        public string PictureURL { get; set; }
        public string Description { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}