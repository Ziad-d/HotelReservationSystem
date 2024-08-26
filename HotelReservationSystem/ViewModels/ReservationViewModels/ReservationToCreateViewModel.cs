﻿namespace HotelReservationSystem.ViewModels.ReservationViewModels
{
    public class ReservationToCreateViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public List<int> RoomIDs { get; set; }
    }
}
