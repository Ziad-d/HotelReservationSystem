﻿namespace HotelReservationSystem.DTOs.ReservationDTOs
{
    public class ReservationToReturnDTO
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<int> RoomIDs { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
