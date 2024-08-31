using HotelReservationSystem.DTOs.ReservationDTOs;

namespace HotelReservationSystem.Mediators.ReservationMediators
{
    public interface IReservationMediator
    {
        Task<ReservationToReturnDTO> Add(ReservationToCreateDTO reservationDTO);
    }
}    
