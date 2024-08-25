using HotelReservationSystem.DTOs.ReservationDTOs;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        void Add(ReservationToCreateDTO reservationToCreateDTO);
    }
}
