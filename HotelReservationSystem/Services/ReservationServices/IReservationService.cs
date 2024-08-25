using HotelReservationSystem.DTOs.ReservationDTOs;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        void Add(ReservationToCreateDTO reservationToCreateDTO);
        IEnumerable<ReservationToReturnDTO> GetAll();
        ReservationToReturnDTO GetById(int id);
        void CancelReservation(int id);
    }
}
