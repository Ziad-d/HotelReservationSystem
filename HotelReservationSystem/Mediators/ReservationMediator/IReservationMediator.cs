using HotelReservationSystem.DTOs.ReservationDTOs;

namespace HotelReservationSystem.Mediators.ReservationMediator
{
    public interface IReservationMediator
    {
        Task<ReservationToReturnDTO> Add(ReservationToCreateDTO reservationDTO);
    }
}    
