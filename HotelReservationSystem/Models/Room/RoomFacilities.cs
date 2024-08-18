namespace HotelReservationSystem.Models.Room
{
    public class RoomFacilities : BaseModel
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
