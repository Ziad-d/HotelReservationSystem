using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.DTOs.ReservationDTOs
{
    public class ReservationToCreateDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<int> RoomIDs { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal TotalAmount { get; set; }

    }
}

