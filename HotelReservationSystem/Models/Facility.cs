namespace HotelReservationSystem.Models
{
    public class Facility : BaseModel
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public HashSet<RoomFacilities> RoomFacilities { get; set; }
    }
}
