using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Add(ReservationToCreateDTO reservationDTO)
        {
            var reservation = MapperHelper.MapOne<Reservation>(reservationDTO);
            _unitOfWork.GetRepo<Reservation>().Add(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();
        }
    }
}
