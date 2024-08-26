namespace HotelReservationSystem.Models
{
    public class Reservation : BaseModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCanceled { get; set; } = false;
        public List<Room> Rooms { get; set; }
    }
}
