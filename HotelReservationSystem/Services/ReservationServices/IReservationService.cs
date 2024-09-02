using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<Reservation> AddAsync(ReservationToCreateDTO reservationDTO);
        IEnumerable<ReservationToReturnDTO> GetAll();
        ReservationToReturnDTO GetById(int id);
        int GetReservationCount(ReservationFilterDTO filter);
        //void CancelReservation(int id);
    }
}
