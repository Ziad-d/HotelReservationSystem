using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<Reservation> AddAsync(ReservationToCreateDTO reservationDTO);
        IEnumerable<ReservationToReturnDTO> GetAll();
        ReservationToReturnDTO GetById(int id);
        //void CancelReservation(int id);
    }
}
