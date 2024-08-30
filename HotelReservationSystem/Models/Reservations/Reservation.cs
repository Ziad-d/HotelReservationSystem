using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.Models.Reservations
{
    public class Reservation : BaseModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfReservedDays
        {
            get
            {
                return (CheckOutDate - CheckInDate).Days;
            }
        }
        public bool IsCanceled { get; set; } = false;
        public List<Room> Rooms { get; set; }
        public string? PaymentIntentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
