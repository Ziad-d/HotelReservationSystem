using HotelReservationSystem.Enums;
using HotelReservationSystem.Models.Rooms;

namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToUpdateViewModel
    {
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfReservedDays { get; set; }
        public bool IsCanceled { get; set; } = false;
        public PaymentStatus PaymentStatus { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal TotalAmount { get; set; }
        //public List<Room> Rooms { get; set; }

    }
}
