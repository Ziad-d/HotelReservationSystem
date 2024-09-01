using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<Reservation> AddAsync(ReservationToCreateDTO reservationDTO);
        IEnumerable<ReservationToReturnDTO> GetAllReservations();
        ReservationToReturnDTO GetSingleReservation(int id);
        bool CancelReservation(int reservationId);
    }
}
